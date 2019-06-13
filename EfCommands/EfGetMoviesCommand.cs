using Application.Commands;
using Application.DTO;
using Application.Searches;
using EntityFramework_DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Application.Responses;

namespace EfCommands
{
    public class EfGetMoviesCommand : EfBaseCommand, IGetMoviesCommand
    {
        public EfGetMoviesCommand(Context context) : base(context)
        {
        }

        public PagedResponse<MovieDTO> Execute(MovieSearch request)
        {
            var query = context.Movies
                .Include(mg => mg.Movie_Genre).ThenInclude(g => g.Genre)
                .Include(ma => ma.Movie_Actor).ThenInclude(a => a.Actor).AsQueryable();

            if (request.Title != null)
            {
                var keyword = request.Title.ToLower();
                query = query.Where(r => r.Title.ToLower().Contains(keyword));
            }

            if (request.GenreId != null)
            {
                query = query.Where(x => x.Movie_Genre.Any(mg => mg.Genre.Id == request.GenreId));
            }

            if (request.CinemaId != null)
            {
                query = query.Where(x => x.Movie_Cinema.Any(mc => mc.Cinema.Id == request.CinemaId));
            }

            if (request.StartShowingDate.HasValue)
            {
                query = query.Where(d => d.StartShowingFrom.Value >= request.StartShowingDate.Value);
            }

            query = query.Where(ff => ff.IsDeleted == false);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponse<MovieDTO>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    StartShowingFrom = m.StartShowingFrom,
                    DurationMins = m.DurationMins,
                    Country = m.Country,
                    Year = m.Year,
                    PictureUrl = m.PictureUrl,
                    Actors = m.Movie_Actor.Select(x => new ActorDTO
                    {
                        Id = x.Id,
                        FirstName = x.Actor.FirstName,
                        LastName = x.Actor.LastName

                    }).ToList(),
                    Genres = m.Movie_Genre.Select(x => new GenreDTO
                    {
                        Id = m.Id,
                        Name = x.Genre.Name
                    }).ToList()

                }).ToList()
            };

            return response;
        }
    }
}

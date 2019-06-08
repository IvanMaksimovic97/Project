using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EntityFramework_DataAccess;

namespace EfCommands
{
    public class EfCreateMovieCommand : EfBaseCommand, ICreateMovieCommand
    {
        public EfCreateMovieCommand(Context context) : base(context)
        {
        }

        public void Execute(CreateMovieDTO request)
        {
            if (Validation(request))
            {
                var movie = new Movie
                {
                    CreatedAt = DateTime.Now,
                    Title = request.Title,
                    StartShowingFrom = request.StartShowingFrom,
                    DurationMins = request.DurationMins,
                    Country = request.Country,
                    Year = request.Year,
                    PictureUrl = request.PictureUrl,
                    IsDeleted = false
                };

                foreach(var actorId in request.ActorsIds)
                {
                    context.Movies_Actors.Add(new Movie_Actor
                    {
                        CreatedAt = DateTime.Now,
                        Movie = movie,
                        Actor = context.Actors.Find(actorId)
                    });
                }

                foreach(var genreId in request.GenresIds)
                {
                    context.Movies_Genres.Add(new Movie_Genre
                    {
                        CreatedAt = DateTime.Now,
                        Movie = movie,
                        Genre = context.Genres.Find(genreId)
                    });
                }

                context.SaveChanges();
            }
        }

        public bool Validation(CreateMovieDTO request)
        {
            foreach(var actorId in request.ActorsIds)
            {
                var actor = context.Actors.Find(actorId);
                if (actor == null)
                    throw new EntityNotFoundException("Glumac nije proandjen");
            }

            foreach(var genreId in request.GenresIds)
            {
                var genre = context.Genres.Find(genreId);
                if (genre == null)
                    throw new EntityNotFoundException("Zanr nije pronadjen");
            }

            if (context.Movies.Any(x => x.Title == request.Title))
                throw new EntityAlreadyExist("Film vec postoji");
           

            return true;
        }
    }
}

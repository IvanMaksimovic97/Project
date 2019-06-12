using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetOneMovieCommand : EfBaseCommand, IGetOneMovieCommand
    {
        public EfGetOneMovieCommand(Context context) : base(context)
        {
        }

        public MovieDTO Execute(int request)
        {
            var movie = context.Movies.Find(request);
            if (movie == null)
                throw new EntityNotFoundException("Film nije pronadjen");

            var movieDto = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                StartShowingFrom = movie.StartShowingFrom,
                DurationMins = movie.DurationMins,
                Country = movie.Country,
                Year = movie.Year,
                PictureUrl = movie.PictureUrl
            };

            return movieDto;
        }
    }
}

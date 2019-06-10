using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditMovieCommand : EfBaseCommand, IEditMovieCommand
    {
        public EfEditMovieCommand(Context context) : base(context)
        {
        }

        public void Execute(EditMovieDTO request)
        {
            if (Validate(request))
            {
                Movie movie = context.Movies.Find(request.MovieId);

                if(request.Title != null)
                    movie.Title = request.Title;
                
                if(request.StartShowingFrom != null)
                    movie.StartShowingFrom = request.StartShowingFrom;

                if(request.Country != null)
                    movie.Country = request.Country;

                if(request.PictureUrl != null)
                    movie.PictureUrl = request.PictureUrl;

                movie.ModifiedAt = DateTime.Now;

                context.SaveChanges();
            }
        }

        public bool Validate(EditMovieDTO dto)
        {
            if (!context.Movies.Any(m => m.Id == dto.MovieId))
                throw new EntityNotFoundException("Film nije pronadjen");

            return true;
        }
    }
}

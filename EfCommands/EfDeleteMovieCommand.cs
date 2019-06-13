using Application.Commands;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteMovieCommand : EfBaseCommand, IDeleteMovieCommand
    {
        public EfDeleteMovieCommand(Context context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var movie = context.Movies.Find(request);
            if (movie == null)
                throw new EntityNotFoundException("Film nije pronadjen");

            movie.IsDeleted = true;
            movie.ModifiedAt = DateTime.Now;
            context.SaveChanges();
        }
    }
}

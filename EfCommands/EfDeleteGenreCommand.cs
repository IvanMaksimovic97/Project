using Application.Commands;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteGenreCommand : EfBaseCommand, IDeleteGenreCommand
    {
        public EfDeleteGenreCommand(Context context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var genre = context.Genres.Find(request);
            if (genre == null)
                throw new EntityNotFoundException("Zanr nije pronadjen");

            genre.IsDeleted = true;
            genre.ModifiedAt = DateTime.Now;
            context.SaveChanges();
        }
    }
}

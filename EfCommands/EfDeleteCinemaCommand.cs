using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteCinemaCommand : EfBaseCommand, IDeleteCinemaCommand
    {
        public EfDeleteCinemaCommand(Context context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var cinema = context.Cinemas.Find(request);
            if (cinema == null)
                throw new EntityNotFoundException("Bioskop nije pronadjen");

            cinema.IsDeleted = true;
            context.SaveChanges();
        }
    }
}

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
    public class EfCreateCinemaCommand : EfBaseCommand, ICreateCinemaCommand
    {
        public EfCreateCinemaCommand(Context context) : base(context)
        {
        }

        public void Execute(CreateCinemaDTO request)
        {
            if (context.Cinemas.Any(x => x.Name == request.Name))
                throw new EntityAlreadyExist("Bioskop postoji");

            var cinema = new Cinema
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone
            };

            context.Cinemas.Add(cinema);
            context.SaveChanges();
        }
    }
}

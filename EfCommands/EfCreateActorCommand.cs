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
    public class EfCreateActorCommand : EfBaseCommand, ICreateActorCommand
    {
        public EfCreateActorCommand(Context context) : base(context)
        {
        }

        public void Execute(CreateActorDTO request)
        {
            if (context.Actors.Any(an => an.FirstName == request.FirstName) && context.Actors.Any(al => al.LastName == request.LastName))
                throw new EntityAlreadyExist("Glumac vec postoji");

            var actor = new Actor
            {
                CreatedAt = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IsDeleted = false
            };

            context.Actors.Add(actor);
            context.SaveChanges();
        }            
    }
}

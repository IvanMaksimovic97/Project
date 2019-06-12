using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetOneActorCommand : EfBaseCommand, IGetOneActorCommand
    {
        public EfGetOneActorCommand(Context context) : base(context)
        {
        }

        public ActorDTO Execute(int request)
        {
            var actor = context.Actors.Find(request);
            if (actor == null)
                throw new EntityNotFoundException("Glumac nije pronadjen");

            var actorDto = new ActorDTO
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName
            };

            return actorDto;
        }
    }
}

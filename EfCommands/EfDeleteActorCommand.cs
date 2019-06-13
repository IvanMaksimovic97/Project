using Application.Commands;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteActorCommand : EfBaseCommand, IDeleteActorCommand
    {
        public EfDeleteActorCommand(Context context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var actor = context.Actors.Find(request);
            if (actor == null)
                throw new EntityNotFoundException("Glumac nije pronadjen");

            actor.IsDeleted = true;
            context.SaveChanges();
        }
    }
}

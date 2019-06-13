using Application.Commands;
using Application.Exceptions;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(Context context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = context.Users.Find(request);
            if (user == null)
                throw new EntityNotFoundException("Korisnik nije pronadjen");

            user.IsDeleted = true;
            user.ModifiedAt = DateTime.Now;
            context.SaveChanges();
        }
    }
}

using Application.Commands;
using Application.DTO;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetUsersCommand : EfBaseCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(Context context) : base(context)
        {
        }

        public IEnumerable<UserDTO> Execute(UserDTO request)
        {
            var users = context.Users.AsQueryable();

            if (request != null)
            {
                if (request.FirstName != null)
                {
                    var fname = request.FirstName.ToLower();
                    users = users.Where(g => g.FirstName.Contains(fname));
                }

                if (request.LastName != null)
                {
                    var lname = request.LastName.ToLower();
                    users = users.Where(g => g.LastName.Contains(lname));
                }
            }

            users = users.Where(g => g.IsDeleted == false);

            return users.Select(gn => new UserDTO
            {
                Id = gn.Id,
                FirstName = gn.FirstName,
                LastName = gn.LastName,
                Email = gn.Email,
                Role = gn.Role

            }).ToList();
        }
    }
}

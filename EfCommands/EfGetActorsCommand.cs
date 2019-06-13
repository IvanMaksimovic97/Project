using Application.Commands;
using Application.DTO;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetActorsCommand : EfBaseCommand, IGetActorsCommand
    {
        public EfGetActorsCommand(Context context) : base(context)
        {
        }

        public IEnumerable<ActorDTO> Execute(ActorDTO request)
        {
            var actors = context.Actors.AsQueryable();

            if (request != null)
            {
                if (request.FirstName != null)
                {
                    var fname = request.FirstName.ToLower();
                    actors = actors.Where(af => af.FirstName.Contains(fname));
                }

                if (request.LastName != null)
                {
                    var lname = request.LastName.ToLower();
                    actors = actors.Where(al => al.LastName.Contains(lname));
                }
            }

            actors = actors.Where(aa => aa.IsDeleted == false);

            return actors.Select(a => new ActorDTO
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName

            }).ToList();
        }
    }
}

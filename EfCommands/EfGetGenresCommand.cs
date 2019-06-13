using Application.Commands;
using Application.DTO;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetGenresCommand : EfBaseCommand, IGetGenresCommand
    {
        public EfGetGenresCommand(Context context) : base(context)
        {
        }

        public IEnumerable<GenreDTO> Execute(GenreDTO request)
        {
            var genres = context.Genres.AsQueryable();

            if(request != null)
            {
                if(request.Name != null)
                {
                    var name = request.Name.ToLower();
                    genres = genres.Where(g => g.Name.Contains(name));
                }
            }

            genres = genres.Where(g => g.IsDeleted == false);

            return genres.Select(gn => new GenreDTO
            {
                Id = gn.Id,
                Name = gn.Name

            }).ToList();
        }
    }
}

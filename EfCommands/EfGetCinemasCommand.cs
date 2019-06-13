using Application.Commands;
using Application.DTO;
using EntityFramework_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetCinemasCommand : EfBaseCommand, IGetCinemasCommand
    {
        public EfGetCinemasCommand(Context context) : base(context)
        {
        }

        public IEnumerable<CinemaDTO> Execute(CinemaDTO request)
        {
            var cinema = context.Cinemas.AsQueryable();

            if(request.Name != null)
            {
                var name = request.Name.ToLower();
                cinema = cinema.Where(c => c.Name.Contains(name));
            }

            if (request.Address != null)
            {
                var adress = request.Address.ToLower();
                cinema = cinema.Where(c => c.Name.Contains(adress));
            }

            if (request.Phone != null)
            {
                var phone = request.Phone.ToLower();
                cinema = cinema.Where(c => c.Name.Contains(phone));
            }

            cinema = cinema.Where(c => c.IsDeleted == false);

            return cinema.Select(c => new CinemaDTO
            {
                Id = c.Id,
                Address = c.Address,
                Phone = c.Phone,
                Name = c.Name

            }).ToList();
        }
    }
}

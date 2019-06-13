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
    public class EfCreateGenreCommand : EfBaseCommand, ICreateGenreCommand
    {
        public EfCreateGenreCommand(Context context) : base(context)
        {
        }

        public void Execute(CreateGenreDTO request)
        {
            if (context.Genres.Any(an => an.Name == request.Name))
                throw new EntityAlreadyExist("Zanr vec postoji");

            var genre = new Genre
            {
                CreatedAt = DateTime.Now,
                Name = request.Name,
                IsDeleted = false
            };

            context.Genres.Add(genre);
            context.SaveChanges();
        }
    }
}

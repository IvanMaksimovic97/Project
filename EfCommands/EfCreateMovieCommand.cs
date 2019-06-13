using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using EntityFramework_DataAccess;

namespace EfCommands
{
    public class EfCreateMovieCommand : EfBaseCommand, ICreateMovieCommand
    {
        private readonly IEmailSender emailSender;

        public EfCreateMovieCommand(Context context, IEmailSender emailSender) : base(context)
        {
            this.emailSender = emailSender;
        }

        public void Execute(CreateMovieDTO request)
        {
            if (Validation(request))
            {
                var movie = new Movie
                {
                    CreatedAt = DateTime.Now,
                    Title = request.Title,
                    StartShowingFrom = request.StartShowingFrom,
                    DurationMins = request.DurationMins,
                    Country = request.Country,
                    Year = request.Year,
                    PictureUrl = request.PictureUrl,
                    IsDeleted = false
                };

                foreach(var actorId in request.ActorsIds)
                {
                    context.Movies_Actors.Add(new Movie_Actor
                    {
                        CreatedAt = DateTime.Now,
                        Movie = movie,
                        Actor = context.Actors.Find(actorId),
                        IsDeleted = false
                    });
                }

                foreach(var genreId in request.GenresIds)
                {
                    context.Movies_Genres.Add(new Movie_Genre
                    {
                        CreatedAt = DateTime.Now,
                        Movie = movie,
                        Genre = context.Genres.Find(genreId),
                        IsDeleted = false
                    });
                }

                context.SaveChanges();

                emailSender.Subject = "Uspesno ste kreirali film";
                emailSender.Body = "Uspesno ste kreirali film";
                emailSender.ToEmail = "imaksimovic97@gmail.com";
                emailSender.Send();
            }
        }

        public bool Validation(CreateMovieDTO request)
        {
            foreach(var actorId in request.ActorsIds)
            {
                var actor = context.Actors.Find(actorId);
                if (actor == null)
                    throw new EntityNotFoundException("Glumac nije proandjen");
            }

            foreach(var genreId in request.GenresIds)
            {
                var genre = context.Genres.Find(genreId);
                if (genre == null)
                    throw new EntityNotFoundException("Zanr nije pronadjen");
            }

            if (context.Movies.Any(x => x.Title == request.Title))
                throw new EntityAlreadyExist("Film vec postoji");
           
            return true;
        }
    }
}

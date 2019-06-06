using Domain;
using EntityFramework_DataAccess;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            /*context.Movies.Add(new Movie
            {
                 CreatedAt = DateTime.Now,
                 Title = "Juzni Vetar",
                 StartShowingFrom = new DateTime(2018, 6, 5),
                 DurationMins = 125,
                 Country = "Serbia",
                 Year = 2018,
                 IsDeleted = false
            });*/

            /*context.Actors.Add(new Actor
            {
                CreatedAt = DateTime.Now,
                FirstName = "Miodrag",
                LastName = "Radonjic",
                IsDeleted = false
            });*/

            /*context.Genres.Add(new Genre
            {
                CreatedAt = DateTime.Now,
                Name = "Thriller",
                IsDeleted = false
            });*/

            /*context.Cinemas.Add(new Cinema
            {
                CreatedAt = DateTime.Now,
                Name = "Cineplexx BIG Beograd",
                Address = "Višnjička 84",
                Phone = "+381 11 40 40 780",
                IsDeleted = false
            });*/

            /*context.Movies_Genres.Add(new Movie_Genre
            {
                CreatedAt = DateTime.Now,
                MovieId = context.Movies.First(x => x.Title == "Balkanska Medja").Id,
                GenreId = context.Genres.First(x => x.Name == "").Id,
                IsDeleted = false
            });*/

            /*context.Movies_Actors.Add(new Movie_Actor
            {
                CreatedAt = DateTime.Now,
                MovieId = context.Movies.First(x => x.Title == "Balkanska Medja").Id,
                ActorId = context.Actors.First(x => x.LastName == "Radoicic").Id,
                IsDeleted = false
            });*/

            /*context.Movies_Cinemas.Add(new Movie_Cinema
            {
                CreatedAt = DateTime.Now,
                MovieId = context.Movies.First(x => x.Title == "Juzni Vetar").Id,
                CinemaId = context.Cinemas.First(x => x.Name == "Cineplexx BIG Beograd").Id
            });*/
            

            //context.SaveChanges();
        }
    }
}

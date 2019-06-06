using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace EntityFramework_DataAccess
{
    public class Context : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie_Genre> Movies_Genres { get; set; }
        public DbSet<Movie_Actor> Movies_Actors { get; set; }
        public DbSet<Movie_Cinema> Movies_Cinemas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PA-26HP\SQLEXPRESS;Initial Catalog=ASP_Projekat;Integrated Security=True;Pooling=False");
        }
    }
}

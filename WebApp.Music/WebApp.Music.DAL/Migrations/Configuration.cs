namespace WebApp.Music.DAL.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Music.DAL.SQLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Music.DAL.SQLContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var music = new List<Album>
            {
                new Album
                {
                  Id=1, Name= "Nevermind", Year=1991, Tracks= new List<Track>
                  {
                      new Track
                      {
                          Id=1, Artist = "Nirvana", Title = "Smells Like Teen Spirit", Time = new TimeSpan(0, 5, 01), AlbumId=1
                      },
                      new Track
                      {
                          Id=2, Artist = "Nirvana", Title = "In Bloom", Time = new TimeSpan(0, 4, 14), AlbumId=1
                      },
                      new Track
                      {
                          Id=3, Artist = "Nirvana", Title = "Come as You Are", Time = new TimeSpan(0, 3, 38), AlbumId=1
                      },
                      new Track
                      {
                          Id=4, Artist = "Nirvana", Title = "Breed", Time = new TimeSpan(0, 3, 03), AlbumId=1
                      }
                  },

                },
                new Album
                {
                    Id=2,Name = "Black Ice", Year = 2008, Tracks = new List<Track>
                    {
                        new Track
                        {
                            Id=5, Artist = "ACDC", Title = "Rock N Roll Train", Time = new TimeSpan(0, 4, 21), AlbumId=2
                        },
                        new Track
                        {
                            Id=6, Artist = "ACDC", Title = "Big Jack", Time = new TimeSpan(0, 3, 57), AlbumId=2
                        }
                    }
                }
            };
            music.ForEach(x => context.Albums.AddOrUpdate(x));
            context.SaveChanges();
        }

    }
}

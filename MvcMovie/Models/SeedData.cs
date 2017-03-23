using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // look for any movies.
                if(context.Movie.Any())
                {
                    return; //Db has been seeded
                }

                context.Movie.AddRange(

                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("11-1-1989"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("13-3-1984"),
                        Genre = "Comedy",
                        Rating = "G",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters II",
                        ReleaseDate = DateTime.Parse("23-2-1986"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("15-4-1959"),
                        Genre = "Western",
                        Rating = "G",
                        Price = 3.99M
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}

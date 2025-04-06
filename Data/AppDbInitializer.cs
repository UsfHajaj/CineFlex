using ETickets.Data.Enum;
using ETickets.Models;

namespace ETickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var ServicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServicesScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                {
                    new Cinema()
                    {
                        Name = "Cinema 1",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                });
                    context.SaveChanges();
                }
                //Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                {
                    new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl  = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                });
                    context.SaveChanges();
                }
                //producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                {
                    new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                });
                    context.SaveChanges();
                }
                //movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            ReleaseDate = DateTime.Now.AddYears(-1),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie(){
                            Title = "Jonny wick",
                            Description = "This is the Jonny wick movie description",
                            Price = 39.50,
                            ImageUrl = "~/images/Jonny wick.jpeg",
                            StartDate = DateTime.Now.AddDays(-9),
                            EndDate = DateTime.Now.AddDays(9),
                            ReleaseDate = DateTime.Now.AddYears(-1),
                            CinemaId = 2,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Title = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            ReleaseDate = DateTime.Now.AddYears(-5),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Title = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            ReleaseDate = DateTime.Now.AddYears(-2),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Title = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            ReleaseDate = DateTime.Now.AddYears(-3),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Title = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            ReleaseDate = DateTime.Now.AddYears(-1).AddMonths(-6),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Title = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            ReleaseDate = DateTime.Now.AddMonths(-8),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //MoveActor
                if (!context.MovieActors.Any())
                {
                    context.MovieActors.AddRange(new List<MovieActors>()
                    {
                        new MovieActors()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new MovieActors()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new MovieActors()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new MovieActors()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new MovieActors()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new MovieActors()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new MovieActors()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new MovieActors()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new MovieActors()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new MovieActors()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new MovieActors()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new MovieActors()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new MovieActors()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new MovieActors()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new MovieActors()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new MovieActors()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new MovieActors()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}

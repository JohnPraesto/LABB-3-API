using LABB_3_API_Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LABB_3_API.Data
{
    public class Labb3ApiDbContext : DbContext
    {
        public Labb3ApiDbContext(DbContextOptions<Labb3ApiDbContext> options) : base(options)
        {
            // Vet inte vad denna gör...
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonHobbyConnection> PersonHobbyConnections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                PersonName = "Georgette",
                Phone = "+468712049"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                PersonName = "Gunnhild",
                Phone = "00000001"
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                PersonName = "Greger",
                Phone = "0704561237"
            });

            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 1,
                HobbyName = "Horseback riding",
                Description = "Pleasant trips out in nature on horseback",
                Links = new List<string> { "https://www.visitvarberg.se/ovrigt/outdoor/outdoorsidor/rida.html" }
            }) ;

            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 2,
                HobbyName = "Tennis",
                Description = "Hitting ball over net with racket",
                Links = new List<string> { "https://www.tennis.se/" }
            });

            modelBuilder.Entity<Hobby>().HasData(new Hobby
            {
                HobbyId = 3,
                HobbyName = "Warhammer",
                Description = "Miniature strategy war game",
                Links = new List<string> { "https://www.warhammer.com/" }
            });

            modelBuilder.Entity<PersonHobbyConnection>().HasData(new PersonHobbyConnection
            {
                ConnectionId = 1,
                HobbyId = 1,
                PersonId = 1
            });

            modelBuilder.Entity<PersonHobbyConnection>().HasData(new PersonHobbyConnection
            {
                ConnectionId = 2,
                HobbyId = 1,
                PersonId = 2
            });

            modelBuilder.Entity<PersonHobbyConnection>().HasData(new PersonHobbyConnection
            {
                ConnectionId = 3,
                HobbyId = 2,
                PersonId = 2
            });

            modelBuilder.Entity<PersonHobbyConnection>().HasData(new PersonHobbyConnection
            {
                ConnectionId = 4,
                HobbyId = 2,
                PersonId = 3
            });

            modelBuilder.Entity<PersonHobbyConnection>().HasData(new PersonHobbyConnection
            {
                ConnectionId = 5,
                HobbyId = 3,
                PersonId = 3
            });

            modelBuilder.Entity<PersonHobbyConnection>().HasData(new PersonHobbyConnection
            {
                ConnectionId = 6,
                HobbyId = 3,
                PersonId = 1
            });
        }
    }
}

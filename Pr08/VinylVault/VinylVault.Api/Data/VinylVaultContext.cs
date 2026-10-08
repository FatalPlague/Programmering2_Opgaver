using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Data
{
    public class VinylVaultContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Record> Records { get; set; }

        public VinylVaultContext(DbContextOptions options) : base(options)
        {  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>();

            SeedRecords(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private void SeedRecords(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasData(
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Artist = "Pink Floyd", Album = "The Dark Side of the Moon", Year = 1973, IsGolden = true },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Artist = "Daft Punk", Album = "Random Access Memories", Year = 2013 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Artist = "Fleetwood Mac", Album = "Rumours", Year = 1977, IsGolden = true },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Artist = "Nirvana", Album = "Nevermind", Year = 1991 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Artist = "Michael Jackson", Album = "Thriller", Year = 1982, IsGolden = true },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Artist = "The Beatles", Album = "Abbey Road", Year = 1969 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Artist = "Kendrick Lamar", Album = "To Pimp a Butterfly", Year = 2015 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Artist = "Radiohead", Album = "OK Computer", Year = 1997 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Artist = "Queen", Album = "A Night at the Opera", Year = 1975 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Artist = "The Prodigy", Album = "The Fat of the Land", Year = 1997 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Artist = "Kanye West", Album = "808s & heartbreak", Year = 2008 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Artist = "Tame Impala", Album = "Currents", Year = 2015 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Artist = "Bob Marley & The Wailers", Album = "Legend", Year = 1984 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Artist = "Kid Cudi", Album = "Man on the Moon", Year = 2009 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Artist = "Arctic Monkeys", Album = "AM", Year = 2013 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Artist = "Amy Winehouse", Album = "Back to Black", Year = 2006 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Artist = "Led Zeppelin", Album = "IV", Year = 1971 },
            new Record { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Artist = "Tyler, The Creator", Album = "IGOR", Year = 2019 }
                );
        }
    }
}

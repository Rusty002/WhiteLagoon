using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Villa> Villas { get; set; }

        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    VillaId = new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28"),
                    VillaName = "Royal Villa",
                    VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    VillaImageUrl = "https://placehold.co/600x400",
                    VillaOccupancy = 4,
                    VillaPrice = 200,
                    VillaSizeInSquareFeet = 550,
                },
                new Villa
                {
                    VillaId = new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c"),
                    VillaName = "Premium Pool Villa",
                    VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    VillaImageUrl = "https://placehold.co/600x401",
                    VillaOccupancy = 4,
                    VillaPrice = 300,
                    VillaSizeInSquareFeet = 550,
                },
                new Villa
                {
                    VillaId = new Guid("83698710-a57a-4c23-bb22-bee22a86a173"),
                    VillaName = "Luxury Pool Villa",
                    VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    VillaImageUrl = "https://placehold.co/600x402",
                    VillaOccupancy = 4,
                    VillaPrice = 400,
                    VillaSizeInSquareFeet = 750,
                });

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28")
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28")
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = new Guid("18198d77-55fb-4d9a-b14d-e8f9f3f6fa28")
                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c")
                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c")
                },
                new VillaNumber
                {
                    Villa_Number = 203,
                    VillaId = new Guid("3a0ba39a-21c1-4f88-8a41-cad14d244f2c")
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = new Guid("83698710-a57a-4c23-bb22-bee22a86a173")
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = new Guid("83698710-a57a-4c23-bb22-bee22a86a173")
                },
                new VillaNumber
                {
                    Villa_Number = 303,
                    VillaId = new Guid("83698710-a57a-4c23-bb22-bee22a86a173")
                });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NZWalks.API.Model.Domain;
using System.Data.Common;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext :DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties  { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }


        // Seed data for Difficulties.
        //Easy, Medium, Hard
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    Id = Guid.Parse("f48e5244-7c7d-4b6f-bb03-b733aafe2d8b"),
                    Name = "Easy"
                },

                new Difficulty
                {
                    Id = Guid.Parse("050732a9-a713-4a04-8d5e-bbea1071d2ba"),
                    Name = "Medium"
                },

                new Difficulty
                {
                    Id =  Guid.Parse("5545d75c-c7b9-46f0-8cdc-da8ba031834e"),
                    Name = "Hard"
                }
            };


            // seed difficulties to the database.

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // Seed data for Regions.

            var region = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("0c94d031-048e-4c8a-8ec8-193e1d00efda"),
                    Name = "Northland",
                    Code = "NZ-NL",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/northland/northland-forest.jpg"

                },
                new Region
                {
                    Id = Guid.Parse("c290cdd9-dff8-40b3-b714-f1eaae755b9a"),
                    Name = "Auckland",
                    Code = "NZ-AK",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-forest.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("b608b9cf-f90b-4890-993d-bca73b0e3a0e"),
                    Name = "Waikato",
                    Code = "NZ-WK",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/waikato/waikato-forest.jpg"
                },

                //new Region
                //{
                //    Id = Guid.Parse("89c9ecac-0d51-4b76-9ff2-87a4d19a73b8"),
                //    Name = "Bay of Plenty",
                //    Code = "NZ-BP",
                //    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/bay-of-plenty/bay-of-plenty-forest.jpg"
                //},
                 
                //new Region
                //{
                //    Id = Guid.Parse("86b07718-9582-4aac-bf70-c0fd1ba1a25b"),
                //    Name = "Gisborne",
                //    Code = "NZ-GS",
                //    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/gisborne/gisborne-forest.jpg"
                //},

                //new Region
                //{
                //    Id = Guid.Parse("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                //    Name = "Hawke's Bay",
                //    Code = "NZ-HB",
                //    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/hawkes-bay/hawkes-bay-forest.jpg"
                //},

                //new Region
                //{
                //    Id = Guid.Parse("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                //    Name = "Taranaki",
                //    Code = "NZ-TK",
                //    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/taranaki/taranaki-forest.jpg"
                //},

                //new Region
                //{
                //    Id = Guid.Parse("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                //    Name = "Queenstown",
                //    Code = "NZ-QT",
                //    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/queenstown/queenstown-forest.jpg"
                //}
            };

            modelBuilder.Entity<Region>().HasData(region);

            // Seed data for Walks.

            

        }
    }
}

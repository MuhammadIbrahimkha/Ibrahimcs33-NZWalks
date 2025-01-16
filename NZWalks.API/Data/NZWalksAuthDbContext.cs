using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }


        // Some Roles 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var readerRoleId = "7be15fd6-74e7-40bf-b46f-8f512df4c692";
            var writerRoleId = "b20a360f-a328-4d92-a29f-8f95bf2a4a0f";

            //Some data for the Roles.

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                   Id = readerRoleId,
                   ConcurrencyStamp = readerRoleId,
                   Name = "Reader",
                   NormalizedName = "Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };



            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}

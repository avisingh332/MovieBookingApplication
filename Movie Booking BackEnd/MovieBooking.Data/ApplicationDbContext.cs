using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<UserBookings> UserBookings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string userId1 = Guid.NewGuid().ToString();
            string userId2 = Guid.NewGuid().ToString();
            string userId3 = Guid.NewGuid().ToString();
            //Password Hasher
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasData(
                     new ApplicationUser
                     {
                         Id = userId1,
                         Name = "Admin",
                         UserName = "admin@test.com",
                         Email = "admin@test.com",
                         NormalizedEmail = "admin@test.com".ToUpper(),
                         NormalizedUserName = "admin@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = userId2,
                         Name = "User 1",
                         UserName = "user1@test.com",
                         NormalizedUserName = "user1@test.com".ToUpper(),
                         Email = "user1@test.com",
                         NormalizedEmail = "user1@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     },
                     new ApplicationUser
                     {
                         Id = userId3,
                         Name = "User 2",
                         UserName = "user2@test.com",
                         NormalizedUserName = "user2@test.com".ToUpper(),
                         Email = "user2@test.com",  
                         NormalizedEmail = "user2@test.com".ToUpper(),
                         PasswordHash = hasher.HashPassword(null, "string")
                     }
                );
            });


            var adminRoleId = "80ee5384-80a7-4aac-b4c8-b80b7dd25ac1";
            var userRoleId = "95cb1e1c-d8b6-45a2-b240-6d211c06fd00";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Id = userRoleId,
                    Name  = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = userRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var assignRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = userId1,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = userId2,
                    RoleId = userRoleId
                },
                new()
                {
                    UserId = userId3,
                    RoleId = userRoleId
                },
              
            };
            builder.Entity<IdentityUserRole<string>>().HasData(assignRoles);
        }

    }
}

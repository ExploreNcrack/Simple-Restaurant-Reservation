using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Data
{
    // inherit the DbContext
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // This constructor is how the ASP.NET creates an instance of ApplicationDbContext
            // options object containing details such as the connection string 
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // use Flutent API to configure relationships
            //modelBuilder.Entity<User>()    // One-To-Many
            //    .HasMany(u => u.Reservations)
            //    .WithOne(r => r.User);
            modelBuilder.Entity<Reservation>()   // Many-To-One
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace Flight_Booking.Models
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flight { get; set; }



        public DbSet<FlightAdmin> FlightAdmin { get; set; }

        public DbSet<Passenger> Passenger { get; set; }


        public DbSet<RegisterUser> RegisterUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<FlightAdmin>()
                .HasOne(b => b.Flight)
                .WithMany(a => a.FlightAdmin)
                .HasForeignKey(p => p.FlightId);

            modelBuilder.Entity<Passenger>()
                .HasOne(b => b.Flight)
                .WithMany(a => a.Passenger)
                .HasForeignKey(p => p.FlightId);
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2633JJUA\\MSSQLSERVER02;Initial Catalog=practice;Integrated Security=True;trustservercertificate=true");

        }



    }

    }


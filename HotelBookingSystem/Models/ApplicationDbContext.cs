using Flight_Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }


        public DbSet<Customer> Customer { get; set; }

        public DbSet<Booking> Booking { get; set; }




        public DbSet<RegisterUser> RegisterUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>()
                .HasOne(b => b.Hotel)
                .WithMany(a => a.Room)
                .HasForeignKey(p => p.HotelId);



            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(a => a.Booking)
                .HasForeignKey(p => p.CustId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(a => a.Booking)
                .HasForeignKey(p => p.RoomId);


        }
















       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2633JJUA\\MSSQLSERVER02;Initial Catalog=hbs;Integrated Security=True;trustservercertificate=true");

        }*/



    }
}

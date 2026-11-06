using __Hotel_Room_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace __Hotel_Room_Management_System.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-BOE44J86\\SQLEXPRESS01;" +
                "Database=HotelManagementDB;TrustServerCertificate=True;Trusted_Connection=True");

        }
    }
}

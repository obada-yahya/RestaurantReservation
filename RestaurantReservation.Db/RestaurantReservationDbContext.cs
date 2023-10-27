using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservationDomain;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EKG9OL3\SQLEXPRESS;Database=RestaurantReservationCore;Trusted_Connection=True;")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasOne<Restaurant>().WithMany().HasForeignKey(table => table.RestaurantId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>().HasOne<Restaurant>().WithMany().HasForeignKey(reservation => reservation.RestaurantId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MenuItem>().HasOne<Restaurant>().WithMany().HasForeignKey(menuItem => menuItem.RestaurantId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>().HasOne<Restaurant>().WithMany().HasForeignKey(employee => employee.RestaurantId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>().HasOne<Reservation>().WithMany().HasForeignKey(order => order.ReservationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

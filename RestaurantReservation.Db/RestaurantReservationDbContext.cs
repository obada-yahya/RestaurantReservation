using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.RestaurantReservationDomain;

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
        
        [DbFunction("CalculateTotalRevenueOfRestaurant","dbo")]
        public double CalculateTotalRevenueOfRestaurant(int restaurantId) 
            => throw new NotImplementedException();
        
        public DbSet<ReservationsFullDetails> ReservationsFullDetails { get; set; }
        public DbSet<EmployeesWithRestaurantDetails> EmployeesWithRestaurantDetails { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EKG9OL3\SQLEXPRESS;Database=RestaurantReservationCore;Trusted_Connection=True;")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationsFullDetails>().HasNoKey()
                .ToView(nameof(ReservationsFullDetails));
            
            modelBuilder.Entity<EmployeesWithRestaurantDetails>().HasNoKey()
                .ToView(nameof(EmployeesWithRestaurantDetails));

        }
    }
}

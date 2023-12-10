using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Repositories.EmployeeRepositories;
using RestaurantReservation.Services.ReservationServices;

namespace RestaurantReservation.Utils;

public static class RestaurantReservationOperations
{

    public static List<Employee> ListMangers()
    {
        try
        {
            using var context = new RestaurantReservationDbContext();
            return context.Employees.Where(employee => employee.Position.ToLower().Equals("manager")).ToList();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return new List<Employee>();
    }

    public static List<Reservation> GetReservationsByCustomer(int customerId)
    {
        using var context = new RestaurantReservationDbContext();
        return context.Reservations.Where(reservation => reservation.CustomerId == customerId).ToList();
    }

    public static List<Order> ListOrdersAndMenuItems(int reservationId)
    {
        try
        {
            var reservationService = new ReservationService(new RestaurantReservationDbContext());
            return reservationService.FindReservation(reservationId).Orders.ToList();
        }
        catch (NullReferenceException exception)
        {
            Console.WriteLine("Orders Doesn't exists for the given reservation ID.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return new List<Order>();
    }

    public static List<MenuItem> ListOrderedMenuItems(int reservationId)
    {
        try
        {
            var orders = ListOrdersAndMenuItems(reservationId);
            return (from order in orders from orderItem in order.OrderItems select orderItem.MenuItem).ToList();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return new List<MenuItem>();
    }

    public static async Task<float?> CalculateAverageOrderAmount(int employeeId)
    {
        try
        {
            var employeeService = new EmployeeRepository(new RestaurantReservationDbContext());
            var employee = await employeeService.FindEmployeeAsync(employeeId);
            return employee.OrdersServed.Sum(orderServed => orderServed.TotalAmount);
        }
        catch (Exception e)
        {
            Console.WriteLine("Employee Doesn't exists for the given ID.");
        }
        return null;
    }
}
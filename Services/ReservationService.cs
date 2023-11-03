using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;
using RestaurantReservation.Services.Interfaces;

namespace RestaurantReservation.Services;

public class ReservationService: IReservationService
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationService(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void AddReservation(Reservation reservation)
    {
        try
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private List<Reservation> GetReservationWithDetails(IQueryable<Reservation> reservations)
    {
        return reservations
            .Select(reservation => new Reservation
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                RestaurantId = reservation.RestaurantId,
                TableId = reservation.TableId,
                ReservationDate = reservation.ReservationDate,
                PartySize = reservation.PartySize,
                Orders = reservation.Orders.Select(order => new Order
                {
                    Id = order.Id,
                    EmployeeId = order.EmployeeId,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    OrderItems = order.OrderItems.Select(orderItem => new OrderItems
                    {
                        Id = orderItem.Id,
                        ItemId = orderItem.ItemId,
                        Quantity = orderItem.Quantity,
                        MenuItem = _context.MenuItems.FirstOrDefault(menuItem => menuItem.Id == orderItem.ItemId)
                    }).ToList()
                }).ToList()
            }).ToList();
    }
    
    public List<Reservation> GetReservations()
    {
        try
        {
            return GetReservationWithDetails(_context.Reservations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Reservation>();
    }
    
    public Reservation? FindReservation(int id)
    {
        try
        {
            return GetReservationWithDetails(_context.Reservations.Where(reservation => reservation.Id == id)).Single();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("There's no reservation exists with the given ID.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public void UpdateReservation(Reservation reservation)
    {
        try
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void DeleteReservation(int id)
    {
        try
        {
            _context.Reservations.Remove(new Reservation(){Id = id});
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
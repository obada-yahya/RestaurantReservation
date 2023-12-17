using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RestaurantReservation.Db;
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.ReservationRepositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> AddReservationAsync(Reservation reservation)
    {
        try
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        catch (DbUpdateException e)
        {
            return null;
        }
    }
    
    private IIncludableQueryable<Reservation, MenuItem> GetReservationWithDetails()
    {
        return _context.Reservations.Include(reservation => reservation.Orders)
            .ThenInclude(order => order.OrderItems)
            .ThenInclude(orderItems => orderItems.MenuItem);
    }

    public async Task<IEnumerable<Reservation>> GetReservationsAsync()
    {
        try
        {
            return await GetReservationWithDetails().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return new List<Reservation>();
    }

    public async Task<Reservation?> FindReservationAsync(int id)
    {
        try
        {
            return await GetReservationWithDetails().SingleAsync(reservation => reservation.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(int id)
    {
        _context.Reservations.Remove(new Reservation(){Id = id});
        await _context.SaveChangesAsync();
    }
}
using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Repositories.ReservationRepositories;

public interface IReservationRepository
{
    public Task<Reservation?> AddReservationAsync(Reservation reservation);
    public Task<IEnumerable<Reservation>> GetReservationsAsync();
    public Task<Reservation?> FindReservationAsync(int id);
    public Task UpdateReservationAsync(Reservation reservation);
    public Task DeleteReservationAsync(int id);
}
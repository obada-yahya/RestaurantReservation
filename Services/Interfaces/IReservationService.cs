using RestaurantReservation.Db.RestaurantReservationDomain;

namespace RestaurantReservation.Services.Interfaces;

public interface IReservationService
{
    public void AddReservation(Reservation reservation);
    public List<Reservation> GetReservations();
    public Reservation? FindReservation(int id);
    public void UpdateReservation(Reservation reservation);
    public void DeleteReservation(int id);
}
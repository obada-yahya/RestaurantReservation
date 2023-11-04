namespace RestaurantReservation.Db.KeylessEntities;

public class ReservationsFullDetails
{
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerEmail { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string RestaurantOpeningHours { get; set; }
    public string RestaurantPhoneNumber { get; set; }
}
namespace RestaurantReservation.Db.RestaurantReservationDomain;

public class Table
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public int Capacity { get; set; }
}
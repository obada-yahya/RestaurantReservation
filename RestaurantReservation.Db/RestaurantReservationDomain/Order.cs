namespace RestaurantReservation.Db.RestaurantReservationDomain;

public class Order
{
    public Order()
    {
        OrderItems = new List<OrderItems>();
    }
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public int? EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public float TotalAmount { get; set; }
    public List<OrderItems> OrderItems { get; set; }
}
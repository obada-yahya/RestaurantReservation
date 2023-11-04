namespace RestaurantReservation.Db.RestaurantReservationDomain;

public class OrderItems
{
    public int Id {  get; set; }
    public int OrderId { get; set; }
    public int MenuItemId {  get; set; }
    public int Quantity { get; set; }
    public MenuItem MenuItem { get; set; }
}
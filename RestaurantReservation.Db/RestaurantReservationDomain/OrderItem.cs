namespace RestaurantReservationDomain
{
    public class OrderItems
    {
        public int id {  get; set; }
        public int OrderId { get; set; }
        public int ItemId {  get; set; }
        public int Quantity { get; set; }
    }
}
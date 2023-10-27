namespace RestaurantReservationDomain
{
    public class Order
    {
        public Order()
        {
            MenuItems = new List<MenuItem>();
        }
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalAmount { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
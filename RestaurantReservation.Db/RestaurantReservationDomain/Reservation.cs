namespace RestaurantReservationDomain
{
    public class Reservation
    {
        public Reservation()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set;}
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public List<Order> Orders { get; set; }
    }
}
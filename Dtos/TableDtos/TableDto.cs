namespace RestaurantReservation.Dtos.TableDtos;

public class TableDto
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public int Capacity { get; set; }
}
namespace RestaurantReservation.Dtos.MenuItemDtos;

public class MenuItemForUpdateDto
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price {  get; set; }
}
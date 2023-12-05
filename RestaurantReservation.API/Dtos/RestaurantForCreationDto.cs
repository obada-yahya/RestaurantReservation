using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Dtos;

public class RestaurantForCreationDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    [Required]
    public string OpeningHours { get; set; }
    
    public RestaurantForCreationDto(string name, string address, string phoneNumber, string openingHours)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        OpeningHours = openingHours;
    }
}
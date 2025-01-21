using System.ComponentModel.DataAnnotations;

public class Service
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Range(0, 1000)]
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public List<AppointmentService> AppointmentServices { get; set; }
} 
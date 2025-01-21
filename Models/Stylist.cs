using System.ComponentModel.DataAnnotations;

public class Stylist
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Appointment> Appointments { get; set; }
} 
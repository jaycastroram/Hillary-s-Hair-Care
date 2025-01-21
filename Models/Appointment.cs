public class Appointment
{
    public int Id { get; set; }
    public DateTime ScheduledFor { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public bool IsCanceled { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<AppointmentService> AppointmentServices { get; set; }
} 
namespace Simulation2.BL.DTOs.TechnicianDTOs;

public class TechnicianGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string ImagePath { get; set; }
    public int ServiceId { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

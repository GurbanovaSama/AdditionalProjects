namespace Simulation2.BL.DTOs.TechnicianDTOs
{
    public class TechnicianUpdateDto
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ServiceId { get; set; }
        public string ImagePath { get; set; }
    }
}

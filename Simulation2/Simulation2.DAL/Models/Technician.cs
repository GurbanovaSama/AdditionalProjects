using Simulation2.DAL.Models.Base;

namespace Simulation2.DAL.Models;

public class Technician : BaseAuditableEntity
{
    public string Name { get; set; }    
    public string Position { get; set; }
    public string ImagePath { get; set; }   
    public int ServiceId { get; set; }  
    public Service? Service { get; set; }
}

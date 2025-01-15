using Simulation2.DAL.Models.Base;

namespace Simulation2.DAL.Models;

public class Service : BaseAuditableEntity
{
    public string Name { get; set; }    
    public string Description { get; set; }
    public ICollection<Technician>? Technicians { get; set; }       
}

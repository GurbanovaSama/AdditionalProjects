namespace Simulation2.DAL.Models.Base;

public class BaseAuditableEntity : BaseEnttity
{
    public DateTime CreatedAt { get; set; }     
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }         
}

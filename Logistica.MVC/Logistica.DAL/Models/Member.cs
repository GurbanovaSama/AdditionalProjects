using Logistica.DAL.Models.Base;

namespace Logistica.DAL.Models;

public class Member : BaseAuiditableEntity
{
    public string Name { get; set; }    
    public string Position { get; set; }    
    public string ImagePath { get; set; }  
    public int ServiceId { get; set; }  
    public Service? Service { get; set; } 
    public ICollection<MembersClients>? MembersClients { get; set; } 
}
 
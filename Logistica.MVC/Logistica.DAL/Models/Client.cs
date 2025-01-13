using Logistica.DAL.Models.Base;

namespace Logistica.DAL.Models;

public class Client : BaseAuiditableEntity
{
    public string Name { get; set; }    
    public string Position { get; set; }    
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public ICollection<MembersClients>? MembersClients { get; set; }
}

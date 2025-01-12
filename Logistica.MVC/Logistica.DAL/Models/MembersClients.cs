namespace Logistica.DAL.Models;

public class MembersClients
{
    public int MemberId { get; set; }       
    public Member? Member { get; set; }  
    public int ClientId { get; set; }       
    public Client? Client { get; set; }
}

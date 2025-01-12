using Logistica.DAL.Models.Base;

namespace Logistica.DAL.Models
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }    
        public string Description { get; set; } 
        public string ImagePath { get; set; }   
        public ICollection<Member>? Members { get; set; }
    }
}

using Logistica.DAL.Models.Base;

namespace Logistica.DAL.Models
{
    public class SliderItem : BaseAuiditableEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; } 
        public string Text { get; set; }    
    }
}

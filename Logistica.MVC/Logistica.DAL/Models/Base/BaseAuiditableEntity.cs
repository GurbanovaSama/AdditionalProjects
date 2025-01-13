namespace Logistica.DAL.Models.Base
{
    public abstract class BaseAuiditableEntity : BaseEntity
    {
        public DateTime? CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; } 
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using Logistica.DAL.Models.Base;

namespace Logistica.MVC.Repositories.Abstractions
{
    public interface IWriteRepo<T> : IRepo<T> where T : BaseEntity, new()
    {
        Task CreateAsync (T entity);    
        void Update(T entity);  
        void Delete(T entity);
        Task<int> SaveChangeAsync();
    }
}

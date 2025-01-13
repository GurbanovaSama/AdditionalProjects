using Logistica.DAL.Contexts;
using Logistica.DAL.Models.Base;

namespace Logistica.MVC.Repositories.Abstractions;

public interface IReadRepo<T> : IRepo<T> where T : BaseEntity, new()    
{
   
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}

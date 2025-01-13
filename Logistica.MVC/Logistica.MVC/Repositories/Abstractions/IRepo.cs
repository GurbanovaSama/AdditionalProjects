using Logistica.DAL.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Logistica.MVC.Repositories.Abstractions;

public interface IRepo<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
}

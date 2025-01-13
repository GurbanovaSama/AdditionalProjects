using Logistica.DAL.Contexts;
using Logistica.DAL.Models.Base;
using Logistica.MVC.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Logistica.MVC.Repositories.Implementations;

public class WriteRepo<T> : IWriteRepo<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public WriteRepo(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>(); 

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);   
    }

    public async  Task<int> SaveChangeAsync()
    {
       int rows =await _context.SaveChangesAsync();  
       return rows;
    }

    public void Update(T entity)
    {
        Table.Update(entity);   
    }
}

using Logistica.DAL.Contexts;
using Logistica.DAL.Models.Base;
using Logistica.MVC.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Logistica.MVC.Repositories.Implementations;

public class ReadRepo<T> : IReadRepo<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public ReadRepo(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>(); 
    public async Task<List<T>> GetAllAsync()
    {
       return await Table.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
        _context.Entry(entity).State = EntityState.Detached;
        return entity;
    }
}

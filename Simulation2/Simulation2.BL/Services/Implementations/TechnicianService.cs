using Microsoft.EntityFrameworkCore;
using Simulation2.BL.DTOs.TechnicianDTOs;
using Simulation2.BL.Services.Abstractions;
using Simulation2.DAL.Contexts;
using AutoMapper;
using Simulation2.DAL.Models;
using Simulation2.BL.Exceptions;

namespace Simulation2.BL.Services.Implementations;

public class TechnicianService : ITechnicianService
{
    private readonly AppDbContexts _context;
    private readonly IMapper _mapper;

    public TechnicianService(AppDbContexts context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public DbSet<Technician> Table => _context.Set<Technician>();   

    public async Task CreateASync(TechnicianAddDto tecnicianDto)
    {
        Technician technician = _mapper.Map<Technician>(tecnicianDto);   
        await Table.AddAsync(technician);
        int rows = await _context.SaveChangesAsync();
        if (rows != 1)
        {
            throw new EntityNotFoundException("Technician cannot be added");    
        }
    }

    public async Task<ICollection<TechnicianGetDto>> GetAllAsync()
    {
        ICollection<TechnicianGetDto> technicians = (ICollection<TechnicianGetDto>)await Table.ToListAsync();
        return _mapper.Map<ICollection<TechnicianGetDto>>(technicians);
    }

    public async Task<TechnicianGetDto> GetByIdAsync(int id)
    {

        Technician? technician = await Table.FindAsync(id);
        if (technician is null)
        {
            throw new EntityNotFoundException("Item is not found");
        }
        return _mapper.Map<TechnicianGetDto>(technician);
    }

    public async Task HardDeleteAsync(int id)
    {
        Technician? technician = await Table.FindAsync(id);
        if (technician is null)
        {
            throw new Exception();
        }
        Table.Remove(technician);
    }

    public async Task SoftDeleteAsync(int id)
    {
        Technician? technician = await Table.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (technician is null) 
        {
            throw new Exception();
        }
        technician.IsDeleted = true;
        technician.CreatedAt = DateTime.Now;
        technician.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();  
    }

    public async Task Update(int id, TechnicianUpdateDto technician)
    {
        var technicianEntity = await GetByIdAsync(id);  
        Technician updatedTechnician = _mapper.Map<Technician>(technician);
        updatedTechnician.CreatedAt = DateTime.UtcNow.AddHours(4);
        updatedTechnician.Id = id;
        _context.Update(updatedTechnician);    
        await _context.SaveChangesAsync();   
    }
}










  
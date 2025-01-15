using Simulation2.BL.DTOs.TechnicianDTOs;

namespace Simulation2.BL.Services.Abstractions;

public interface ITechnicianService
{
    Task<ICollection<TechnicianGetDto>> GetAllAsync();
    Task<TechnicianGetDto> GetByIdAsync(int id);
    Task CreateASync(TechnicianAddDto tecnicianDto);
    Task Update(int id, TechnicianUpdateDto technician);    
    Task SoftDeleteAsync (int id);
    Task HardDeleteAsync (int id);
}

using AutoMapper;
using Simulation2.BL.DTOs.TechnicianDTOs;
using Simulation2.DAL.Models;

namespace Simulation2.BL.Profiles
{
    public class TechnicianProfile : Profile
    {
        public TechnicianProfile()
        {
            CreateMap<Technician, TechnicianAddDto>().ReverseMap();  
            CreateMap<Technician, TechnicianGetDto>().ReverseMap(); 
            CreateMap<Technician, TechnicianUpdateDto>().ReverseMap();      
        }
    }
}

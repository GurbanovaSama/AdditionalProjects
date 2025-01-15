using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simulation2.BL.DTOs.TechnicianDTOs;
using Simulation2.BL.Services.Abstractions;
using Simulation2.DAL.Models;

namespace Simulation2.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TechnicianController : Controller
    {

        private readonly ITechnicianService _technicianService;
        private readonly IMapper _mapper;
        public TechnicianController(ITechnicianService technicianService, IMapper mapper)
        {
            _technicianService = technicianService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            ICollection<Technician> technicians = (ICollection<Technician>)await _technicianService.GetAllAsync();
            return View(technicians);   
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();      
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechnicianAddDto tecnicianDto)
        {
            await _technicianService.CreateAsync(tecnicianDto);
            return RedirectToAction(nameof(Index));
        }

    }
}

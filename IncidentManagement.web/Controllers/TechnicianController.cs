using IncidentManagement.Application.Services;
using IncidentManagement.Domain.Entities;
using IncidentManagement.web.Controllers.Dto;
using IncidentManagement.web.Controllers.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.web.Controllers;

[ApiController]
[Route("api/technician")]
public class TechnicianController: ControllerBase
{
    private readonly TechnicianService  _technicianService;
    private readonly TechnicianMapper _technicianMapper;

    public TechnicianController(TechnicianService technicianService,  TechnicianMapper technicianMapper)
    {
        _technicianService = technicianService;
        _technicianMapper = technicianMapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTechnician ([FromBody] TechnicianCreateDto technicianCreateDto)
    {
        if (technicianCreateDto == null)
            return BadRequest("User data is required");
        
        Technician technician = _technicianMapper.MapToTechnician(technicianCreateDto);
        await _technicianService.CreateTechnician(technician);
        return Ok(new { message = "Tecnico creado con éxito" });
    }
}
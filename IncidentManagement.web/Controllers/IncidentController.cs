using Microsoft.AspNetCore.Mvc;
using IncidentManagement.Application.Services;
using IncidentManagement.Domain.Entities;
using IncidentManagement.Web.Controllers;

namespace IncidentManagement.web.Controllers.Dto;

[ApiController]
[Route("api/incidents")]
public class IncidentController : ControllerBase
{
    private readonly IncidentService _incidentService;

    public IncidentController(IncidentService incidentService)
    {
        _incidentService = incidentService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateIncident([FromBody] IncidentCreateDto incidentDto)
    {
        try
        {
            if (incidentDto == null)
            {
                return BadRequest(new { message = "Datos del incidente no proporcionados." });
            }
            
            var incident = new Incident
            {
                Title = incidentDto.Title,
                Description = incidentDto.Description,
                Priority = Enum.TryParse<IncidentPriority>(incidentDto.Priority, out var priority) 
                    ? priority 
                    : IncidentPriority.Media,// Valor por defecto si la conversión falla
                IdUser = incidentDto.IdUser
            };

            await _incidentService.CreateIncident(incident);
            return CreatedAtAction(nameof(GetByUserId), new { userId = incident.IdUser }, incident);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocurrió un error al crear el incidente.", details = ex.Message });
        }
    }

    // Endpoint para obtener los incidentes por ID de usuario
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest(new { message = "El ID de usuario no puede estar vacío." });
        }

        var incidents = await _incidentService.GetByUserId(userId);

        if (incidents == null || !incidents.Any())
        {
            return NotFound(new { message = "No se encontraron incidentes para este usuario." });
        }

        return Ok(incidents);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFilteredIncidents(
        [FromQuery] string? state, 
        [FromQuery] string? priority, 
        [FromQuery] string? assignedTo, 
        [FromQuery] DateTime? date)
    {
        var incidents = await _incidentService.GetFilteredIncidentsAsync(state, priority, assignedTo, date);
        return Ok(incidents);
    }
    
    [HttpPut("{id}/state")]
    public async Task<IActionResult> UpdateIncidentState(Guid id, [FromBody] UpdateStateRequestDto updateStateRequest)
    {
        var updated = await _incidentService.UpdateStateAsync(id, updateStateRequest.State);
        if (updated == null) return NotFound(new { message = "Incidente no encontrado" });

        return Ok( new { state = updated.State.ToString()});
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteIncident(Guid id)
    {
        await _incidentService.DeleteIncident(id);
        return Ok( new {message = "Incidente eliminado" });
    }


}
using IncidentManagement.Infrastructure.Repositories;
using IncidentManagement.Domain.Entities;

namespace IncidentManagement.Application.Services;

public class IncidentService
{
    private readonly IIncidentRepository _IncidentRepository;

    public IncidentService(IIncidentRepository IncidentRepository)
    {
        _IncidentRepository = IncidentRepository;
    }
    
    public async Task CreateIncident (Incident incident)
    {
        if (incident.IdUser == Guid.Empty) 
        {
            throw new ArgumentException("El ID de usuario no puede estar vacío.");
        }

        Incident addedIncident = new Incident
        {
            Title = incident.Title,
            Description = incident.Description,
            Priority = incident.Priority,
            State = IncidentStatus.Abierto,
            CreatedAt =DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IdUser = incident.IdUser,
        };
        
        await _IncidentRepository.Add(addedIncident);
    }
    
    public async Task <List<Incident>> GetByUserId(Guid userId)
    {
    return await _IncidentRepository.FindByUserId(userId);
    }
    
    public async Task<List<Incident>> GetFilteredIncidentsAsync(string? state, string? priority, string? assignedTo, DateTime? date)
    {
        return await _IncidentRepository.GetFilteredIncidentsAsync(state, priority, assignedTo, date);
    }
    
    public async Task<Incident> UpdateIncidentAsync(Guid id, Incident updatedIncident)
    {
        var existingIncident = await _IncidentRepository.GetById(id);
        if (existingIncident == null)
        {
            throw new KeyNotFoundException("Incidente no encontrado");
        }

        if (!string.IsNullOrWhiteSpace(updatedIncident.Title))
            existingIncident.Title = updatedIncident.Title;

        if (!string.IsNullOrWhiteSpace(updatedIncident.Description))
            existingIncident.Description = updatedIncident.Description;

        if (Enum.IsDefined(typeof(IncidentStatus), updatedIncident.State))
            existingIncident.State = updatedIncident.State;

        if (Enum.IsDefined(typeof(IncidentPriority), updatedIncident.Priority))
            existingIncident.Priority = updatedIncident.Priority;

        existingIncident.UpdatedAt = DateTime.UtcNow;
        
        await _IncidentRepository.Update(existingIncident);
        return existingIncident;
    }
    
    public async Task<Incident?> UpdateStateAsync(Guid incidentId, string newState)
    {
        var incident = await _IncidentRepository.GetByIdAsync(incidentId);
        if (incident == null)
            return null;
        
        if (Enum.TryParse<IncidentStatus>(newState, true, out var status))
        {
            incident.State = status;
        }
        await _IncidentRepository.Update(incident);
        var updatedIncident = await _IncidentRepository.GetByIdAsync(incidentId);
        return updatedIncident;
    }

    public async Task DeleteIncident(Guid id)
    {
        await _IncidentRepository.DeleteById(id);
    }
}
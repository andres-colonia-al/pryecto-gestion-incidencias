using IncidentManagement.Domain.Entities;

namespace IncidentManagement.Infrastructure.Repositories;

public interface IIncidentRepository : IRepository<Incident>
{
    Task <List<Incident>> FindByUserId (Guid userId);
    
    Task<Incident> GetByIdAsync(Guid incidentId);

    Task<List<Incident>> GetFilteredIncidentsAsync(string? state, string? priority, string? assignedTo, DateTime? date);
}
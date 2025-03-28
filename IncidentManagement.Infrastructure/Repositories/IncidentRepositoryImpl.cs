using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Repositories;

public class IncidentRepositoryImpl : RepositoryImp<Incident> , IIncidentRepository
{
    public IncidentRepositoryImpl(AppDbContext context) : base(context) { }

    public async Task<List<Incident>> FindByUserId (Guid userId)
    {
        return await _context.Incidents.Where(i => i.IdUser == userId).ToListAsync();
    }
    
    public async Task<List<Incident>> GetFilteredIncidentsAsync(string? state, string? priority, string? assignedTo, DateTime? date)
    {
        var query = _context.Incidents.AsQueryable(); // Construye la consulta desde la DB

        // Filtro por estado
        if (!string.IsNullOrEmpty(state) && Enum.TryParse(state, out IncidentStatus stateEnum))
            query = query.Where(i => i.State == stateEnum);

        // Filtro por prioridad
        if (!string.IsNullOrEmpty(priority) && Enum.TryParse(priority, out IncidentPriority priorityEnum))
            query = query.Where(i => i.Priority == priorityEnum);

        // Filtro por técnico asignado
        if (!string.IsNullOrEmpty(assignedTo))
        {
            if (assignedTo.Equals("none", StringComparison.OrdinalIgnoreCase))
                query = query.Where(i => i.IdTechnician == null);
            else
                query = query.Where(i => i.IdTechnician.HasValue);
        }

        // Filtro por fecha de creación
        if (date.HasValue)
        {
            DateTime startDate = date.Value.Date.ToUniversalTime(); // ✅ Convertir a UTC
            DateTime endDate = startDate.AddDays(1);
            query = query.Where(i => i.CreatedAt >= startDate && i.CreatedAt < endDate);
        }

        return await query.ToListAsync(); 
    }
    
    public async Task<Incident> GetByIdAsync (Guid incidentId)
    {
        return await _context.Incidents.FindAsync(incidentId);
    }

    public async Task UpdateAsync(Incident incident)
    {
        _context.Incidents.Update(incident);
        await _context.SaveChangesAsync();
    }

}
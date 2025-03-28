using IncidentManagement.Domain.Entities;

namespace IncidentManagement.Infrastructure.Repositories;

public interface ITechnicianRepository : IRepository<Technician>
{
    Task<Technician?> GetByEmailAndPassword(string email, string password);
}
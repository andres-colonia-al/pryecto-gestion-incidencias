using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Repositories;

public class TechnicianRepositoryImpl : RepositoryImp<Technician>, ITechnicianRepository
{
    public TechnicianRepositoryImpl(AppDbContext context) : base(context) { }

    public async Task<Technician?> GetByEmailAndPassword(string email, string password)
    {
        return await _context.Technicians.SingleOrDefaultAsync(t => t.Email == email && t.Password == password);
    }
}
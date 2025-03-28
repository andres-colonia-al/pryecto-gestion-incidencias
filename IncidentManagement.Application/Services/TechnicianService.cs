using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Repositories;

namespace IncidentManagement.Application.Services;

public class TechnicianService
{
    private readonly ITechnicianRepository _TechnicianRepository;

    public TechnicianService(ITechnicianRepository technicianRepository)
    {
        _TechnicianRepository = technicianRepository;
    }

    public async Task<Technician?> GetTechnicianById(Guid id)
    {
        return await _TechnicianRepository.GetById(id);
    }

    public async Task CreateTechnician (Technician technician)
    {
        await _TechnicianRepository.Add(technician);
    }
}
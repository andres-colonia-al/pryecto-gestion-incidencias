using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Repositories;

namespace IncidentManagement.Application.Services;

public class AuthService
{
    private readonly IUserRepository _UserRepository;
    private readonly ITechnicianRepository _TechnicianRepository;

    public AuthService(IUserRepository UserRepository, ITechnicianRepository TechnicianRepository)
    {
        _UserRepository = UserRepository;
        _TechnicianRepository = TechnicianRepository;
    }

    public async Task<(bool isValid, string role, Guid? id)> ValidateUser(string email, string password)
    {
        var user = await _UserRepository.GetByEmailAndPassword(email, password);
        if (user != null) 
        {
            return (true, "Usuario", user.IdUser);
        }
        
        var technician = await _TechnicianRepository.GetByEmailAndPassword(email, password);
        if (technician != null)
        {
            return (true, "Tecnico", technician.IdTechnician);
        }
        
        return (false, string.Empty,  Guid.Empty);
    }
    
}
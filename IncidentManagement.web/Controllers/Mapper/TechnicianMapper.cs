using IncidentManagement.Domain.Entities;
using IncidentManagement.web.Controllers.Dto;

namespace IncidentManagement.web.Controllers.Mapper;

public class TechnicianMapper
{
    public Technician MapToTechnician(TechnicianCreateDto technicianCreateDto)
    {
        if (technicianCreateDto == null)
        {
            Console.WriteLine("El MapToTechnician no puede ser nulo");
        }
        
        if (!Enum.IsDefined(typeof(Technician.TechnicianRole), technicianCreateDto.RoleTechnician))
        {
            throw new ArgumentException($"El AuthorType '{technicianCreateDto.RoleTechnician}' no es válido.");
        }
        
        Technician technician = new Technician
        {
            Name = technicianCreateDto.Name,
            Email = technicianCreateDto.Email,
            Password = technicianCreateDto.Password,
            RoleTechnician = (Technician.TechnicianRole)Enum.Parse(typeof(Technician.TechnicianRole), technicianCreateDto.RoleTechnician),
        };

        return technician;
    }
}
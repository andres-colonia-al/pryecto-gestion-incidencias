using System.ComponentModel.DataAnnotations;

namespace IncidentManagement.Domain.Entities;

public class Technician
{
    [Key]
    public Guid IdTechnician { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public TechnicianRole RoleTechnician { get; set; }

    public virtual List<Incident> AssignedIncidents { get; set; } = new();
    
    public enum TechnicianRole
    {
        Trainee,
        Junior,
        Senior,
        Admin
    }
}
using System.ComponentModel.DataAnnotations;

namespace IncidentManagement.Domain.Entities;

public class User 
{
    [Key]
    public Guid IdUser { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public virtual List<Incident> ReportedIncidents { get; set; } = new();

}
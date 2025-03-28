using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentManagement.Domain.Entities;

public class Incident
{
    [Key]
    public Guid IdIncident { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    public IncidentStatus State { get; set; }
    
    [Required]
    public IncidentPriority Priority { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public DateTime UpdatedAt { get; set; }
    
    [Required]
    public Guid IdUser { get; set; }
    [ForeignKey("IdUser")]
    public virtual User User { get; set; }
    
    public Guid? IdTechnician { get; set; }
    
    [ForeignKey("IdTechnician")]
    public virtual Technician Technician { get; set; }

    public virtual List<Comment> Comments { get; set; } = new();
}

public enum IncidentStatus
{
    Abierto,
    Progreso,
    Resuelto,
    Cerrado
}
public enum IncidentPriority
{
    Baja,
    Media,
    Alta,
    Critica,
}

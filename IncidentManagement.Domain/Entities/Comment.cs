using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentManagement.Domain.Entities;

public class Comment
{
    [Key]
    public Guid IdComment { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Content { get; set; }
    
    [Required]
    public Guid IdIncident { get; set; }

    [ForeignKey("IdIncident")]
    public virtual Incident Incident { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public AuthorType AuthorType { get; set; }
}

public enum AuthorType
{
    Usuario,
    Tecnico
}
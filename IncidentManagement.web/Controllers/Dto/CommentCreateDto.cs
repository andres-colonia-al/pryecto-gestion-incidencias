using IncidentManagement.Domain.Entities;

namespace IncidentManagement.web.Controllers.Dto;

public class CommentCreateDto
{
    public string Content { get; set; }
    public Guid IdIncident { get; set; }
    public string AuthorType { get; set; }
}
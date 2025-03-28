namespace IncidentManagement.web.Controllers.Dto;

public class IncidentCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public Guid IdUser { get; set; }
}
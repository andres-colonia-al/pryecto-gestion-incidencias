using System.Text.Json.Serialization;

namespace IncidentManagement.web.Controllers.Dto;

public class LoginRequestDto
{
    [JsonPropertyName("Email")]
    public string Email { get; set; }
    
    [JsonPropertyName("Password")]
    public string Password { get; set; }
}
using IncidentManagement.Domain.Entities;
using IncidentManagement.web.Controllers.Dto;

namespace IncidentManagement.web.Controllers.Mapper;

public class CommentMapper
{
    public Comment MapToComment(CommentCreateDto commentCreateDto)
    {
        if (commentCreateDto == null)
        {
            Console.WriteLine("El MapToComment no puede ser nulo");
        }
        
        if (!Enum.IsDefined(typeof(AuthorType), commentCreateDto.AuthorType))
        {
            throw new ArgumentException($"El AuthorType '{commentCreateDto.AuthorType}' no es válido.");
        }
        
        Comment comment = new Comment
        {
            Content = commentCreateDto.Content,
            CreatedAt = DateTime.UtcNow,
            AuthorType = (AuthorType)Enum.Parse(typeof(AuthorType), commentCreateDto.AuthorType),
            IdIncident = commentCreateDto.IdIncident,
        };

        return comment;
    }
}
using IncidentManagement.Application.Services;
using IncidentManagement.Domain.Entities;
using IncidentManagement.web.Controllers.Dto;
using IncidentManagement.web.Controllers.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.web.Controllers;

[ApiController]
[Route("api/comment")]
public class CommentController :ControllerBase
{
    private readonly CommentService  _commentService;
    private readonly CommentMapper  _commenMapper;

    public CommentController(CommentService commentService,  CommentMapper commentMapper)
    {
        _commentService = commentService;
        _commenMapper = commentMapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CommentCreateDto commentCreateDto)
    {
        if (commentCreateDto == null)
        {
            return BadRequest("El cuerpo de la solicitud no puede ser nulo");
        }
        
        Comment comment = _commenMapper.MapToComment(commentCreateDto);
        await _commentService.CreateComment(comment);
        
        return Ok(new { message = "Comentario creado con éxito" });
    }

    [HttpGet("{incidentId}")]
    public async Task<IActionResult> GetCommentByIncidentId(Guid incidentId)
    {
        return Ok(await _commentService.GetCommentByIncidentId(incidentId));
    }

}
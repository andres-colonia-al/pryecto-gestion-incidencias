using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Repositories;

namespace IncidentManagement.Application.Services;

public class CommentService
{
    private readonly ICommentRepository _CommentRepository;

    public CommentService(ICommentRepository CommentRepository)
    {
        _CommentRepository = CommentRepository;
    }
    
    public async Task CreateComment(Comment comment)
    {
        await _CommentRepository.Add(comment);
    }

    public async Task<List<Comment>> GetCommentByIncidentId(Guid IncidentId)
    {
        return await _CommentRepository.FindCommentByIncidentId(IncidentId);
    }
}
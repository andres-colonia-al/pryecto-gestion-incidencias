using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Repositories;

public class CommentRepositoryImpl : RepositoryImp<Comment>, ICommentRepository 
{
    public CommentRepositoryImpl(AppDbContext context) : base(context) { }

    public async Task<List<Comment>> FindCommentByIncidentId(Guid incidentId)
    {
        return await _context.Comments.Where(c => c.IdIncident == incidentId).ToListAsync();
    }
}
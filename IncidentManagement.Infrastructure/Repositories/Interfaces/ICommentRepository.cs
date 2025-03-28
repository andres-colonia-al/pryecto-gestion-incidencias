using IncidentManagement.Domain.Entities;

namespace IncidentManagement.Infrastructure.Repositories;

public interface ICommentRepository : IRepository<Comment>
{
    Task <List<Comment>> FindCommentByIncidentId (Guid incidentId);
}
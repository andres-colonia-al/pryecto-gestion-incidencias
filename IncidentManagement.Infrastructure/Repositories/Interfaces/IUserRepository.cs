using IncidentManagement.Domain.Entities;

namespace IncidentManagement.Infrastructure.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAndPassword(string email, string password);
}
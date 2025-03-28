using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Infrastructure.Repositories;

public class UserRepositoryImpl : RepositoryImp<User>, IUserRepository
{
    public UserRepositoryImpl(AppDbContext context) : base(context) { }

    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
using IncidentManagement.Domain.Entities;
using IncidentManagement.Infrastructure.Repositories;

namespace IncidentManagement.Application.Services;

public class UserService
{
    private readonly IRepository<User> _UserRepository;

    public UserService(IRepository<User> UserRepository)
    {
        _UserRepository = UserRepository;
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _UserRepository.GetById(id);
    }

    public async Task CreateUser(User user)
    {
        await _UserRepository.Add(user);
    }
}
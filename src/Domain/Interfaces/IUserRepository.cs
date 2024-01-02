using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<UserEntity?> GetAsync(string name);

    Task<UserEntity> CreateAsync(UserEntity user);
}

using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<UserEntity?> GetByNameAsync(string name);

    Task<UserEntity?> GetByIdAsync(int id);

    Task<UserEntity> CreateAsync(UserEntity user);
}

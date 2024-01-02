using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain.Exceptions;
using Domain.Entities;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> CreateAsync(User user)
    {
        if (await _userRepository.GetByNameAsync(user.Name) is not null)
            throw new UserExistsException(user.Name);

        UserEntity createdUser = await _userRepository.CreateAsync(_mapper.Map<UserEntity>(user));

        return _mapper.Map<User>(createdUser);
    }
}

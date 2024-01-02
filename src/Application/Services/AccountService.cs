using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IUserRepository userRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Account> CreateAsync(CreateAccount account)
    {
        if (await _userRepository.GetByIdAsync(account.UserId) is null)
            throw new UserNotFoundException(account.UserId);

        if (await _accountRepository.CountByUserIdAsync(account.UserId) >= 2)
            throw new MaxAccountsException();

        // typeId doesn't exist

        AccountEntity newAccount = new AccountEntity
        {
            Id = GenerateAccountNumber(),
            UserId = account.UserId,
            TypeId = account.TypeId,
            Balance = 0,
            IsDeleted = false
        };

        AccountEntity createdAccount = await _accountRepository.CreateAsync(newAccount);

        return _mapper.Map<Account>(createdAccount);
    }

    private string GenerateAccountNumber()
    {
        var randomNumber = new Random();
        return $"LT{randomNumber.Next(100000,999999)}";
    }
}

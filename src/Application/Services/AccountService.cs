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
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository, IUserRepository userRepository, ITransactionRepository transactionRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;
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

    public async Task<Account> TopUpAsync(string id, decimal amount)
    {
        if (await _accountRepository.GetAsync(id) is null)
            throw new AccountNotFoundException(id);

        Transaction transaction = new Transaction
        {
            TypeId = 1,
            Timestamp = DateTime.UtcNow,
            FromAccount = "",
            ToAccount = id,
            Amount = amount,
            Fees = 0
        };

        await _transactionRepository.RegisterAsync(_mapper.Map<TransactionEntity>(transaction));
        AccountEntity updatedAccount = await _accountRepository.ChangeBalanceAsync(id, amount);

        return _mapper.Map<Account>(updatedAccount);
    }

    private string GenerateAccountNumber()
    {
        var randomNumber = new Random();
        return $"LT{randomNumber.Next(100000,999999)}";
    }
}

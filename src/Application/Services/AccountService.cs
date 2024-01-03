using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    const int MAXACCOUNTS = 2;

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

        if (await _accountRepository.CountByUserIdAsync(account.UserId) >= MAXACCOUNTS)
            throw new MaxAccountsException();

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

        if (amount <= 0)
            throw new InvalidAmountException();

        Transaction transaction = new Transaction
        {
            TypeId = 1,
            Timestamp = DateTime.UtcNow,
            Account = id,
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
        return $"LT{randomNumber.Next(100000, 999999)}";
    }
}

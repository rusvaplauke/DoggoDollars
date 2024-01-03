using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Exceptions;

namespace Application.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    const decimal FEES = 1;

    public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<List<Transaction>> GetAsync()
    {
        List<TransactionEntity> transactions = await _transactionRepository.GetAsync();

        return transactions.Select(t => _mapper.Map<Transaction>(t)).ToList();
    }

    public async Task<Transaction> PostAsync(Transaction transaction)
    {
        await VerifyTransaction(transaction);


        // Register transaction for Account
        // Register transaction for CorrespondingAccount
        // Update balance for Account
        // Update balance for CorrespondingAccount


        return new Transaction();
    }

    private async Task VerifyTransaction(Transaction transaction)
    {
        AccountEntity? sender = await _accountRepository.GetAsync(transaction.Account);
        AccountEntity? receiver = await _accountRepository.GetAsync(transaction.CorrespondingAccount);

        if (sender is null)
            throw new AccountNotFoundException(transaction.Account);

        if (receiver is null)
            throw new AccountNotFoundException(transaction.CorrespondingAccount);

        if (sender.Balance <= transaction.Amount + FEES)
            throw new InsufficientFundsException();
    }


}

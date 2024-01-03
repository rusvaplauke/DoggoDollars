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
using System.Diagnostics;
using Application.Dtos;

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

    public async Task<Transaction> PostAsync(TransactionRequest transaction)
    {
        await VerifyTransaction(transaction);
        await RegisterTransaction(transaction);
        await UpdateBalances(transaction);

        return new Transaction();
    }

    private async Task VerifyTransaction(TransactionRequest transaction)
    {
        AccountEntity? sender = await _accountRepository.GetAsync(transaction.SenderAccount);
        AccountEntity? receiver = await _accountRepository.GetAsync(transaction.ReceiverAccount);

        if (transaction.Amount <= 0)
            throw new InvalidAmountException();
        
        if (sender is null)
            throw new AccountNotFoundException(transaction.SenderAccount);

        if (receiver is null)
            throw new AccountNotFoundException(transaction.ReceiverAccount);

        if (receiver.Id == sender.Id)
            throw new SameAccountException();

        if (sender.Balance <= transaction.Amount + FEES)
            throw new InsufficientFundsException();
    }

    private async Task RegisterTransaction(TransactionRequest transaction)
    {
        Transaction senderTransaction = new Transaction
        {
            TypeId = 3,
            Timestamp = DateTime.UtcNow,
            Account = transaction.SenderAccount,
            CorrespondingAccount = transaction.ReceiverAccount,
            Amount = transaction.Amount,
            Fees = FEES
        };

        Transaction receiverTransaction = new Transaction
        {
            TypeId = 2,
            Timestamp = DateTime.UtcNow,
            Account = transaction.ReceiverAccount,
            CorrespondingAccount = transaction.SenderAccount,
            Amount = transaction.Amount
        };

        await _transactionRepository.RegisterAsync(_mapper.Map<TransactionEntity>(senderTransaction));
        await _transactionRepository.RegisterAsync(_mapper.Map<TransactionEntity>(receiverTransaction));
    }

    private async Task UpdateBalances(TransactionRequest transaction)
    {
        await _accountRepository.ChangeBalanceAsync(transaction.SenderAccount, -(transaction.Amount + FEES));
        await _accountRepository.ChangeBalanceAsync(transaction.ReceiverAccount, transaction.Amount);
    }
}

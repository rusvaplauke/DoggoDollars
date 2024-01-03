using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException(string? accountId) : base($"Account {accountId} not found.")
    {

    }
}
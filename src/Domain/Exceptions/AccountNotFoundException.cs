﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException(int accountNumber) : base($"Account {accountNumber} not found.")
    {

    }
}
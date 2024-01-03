﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base($"Insufficient funds for the transfer.")
    {

    }
}

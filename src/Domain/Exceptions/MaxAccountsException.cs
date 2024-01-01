using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class MaxAccountsException : Exception
{
    public MaxAccountsException() : base($"User already has 2 accounts.")
    {

    }
}

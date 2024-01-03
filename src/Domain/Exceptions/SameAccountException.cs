using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class SameAccountException : Exception
{
    public SameAccountException() : base($"The account and corresponding accounts cannot be the same.")
    {

    }
}

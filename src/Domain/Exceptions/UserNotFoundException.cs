﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(int id) : base($"User with id {id} not found.")
    {

    }
}

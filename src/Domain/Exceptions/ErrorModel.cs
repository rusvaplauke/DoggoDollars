﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class ErrorModel
{
    public int Status { get; set; }
    public string? Message { get; set; }
}

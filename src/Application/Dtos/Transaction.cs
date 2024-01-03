using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public class Transaction
{
    public DateTime Timestamp { get; set; }
    public int TypeId { get; set; }
    public string? CorrespondingAccount { get; set; }
    public string Account { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal Fees { get; set; }
}

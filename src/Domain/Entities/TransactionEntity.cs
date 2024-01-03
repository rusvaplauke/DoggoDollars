using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class TransactionEntity
{
    public int Id {  get; set; }
    public DateTime Timestamp {  get; set; } = DateTime.UtcNow;
    public int TypeId { get; set; }
    public string? FromAccount { get; set; }
    public string ToAccount { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal Fees { get; set; }
}

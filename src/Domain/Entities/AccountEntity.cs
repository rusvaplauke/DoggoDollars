using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

internal class AccountEntity
{
    public string Id { get; set; } = "";
    public int UserId { get; set; }
    public int TypeId { get; set; }
    public decimal Balance { get; set; }
    public Boolean IsDeleted { get; set; }
}

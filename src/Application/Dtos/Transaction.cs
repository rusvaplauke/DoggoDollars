namespace Application.Dtos;

public class Transaction
{
    public DateTime Timestamp { get; set; }
    public int TypeId { get; set; }
    public string? CorrespondingAccount { get; set; }
    public string? Account { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal Fees { get; set; }
}

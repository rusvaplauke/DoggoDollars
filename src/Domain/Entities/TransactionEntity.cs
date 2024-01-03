namespace Domain.Entities;

public class TransactionEntity
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public int TypeId { get; set; }
    public string? CorrespondingAccount { get; set; }
    public string? Account { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal Fees { get; set; }
}

namespace Application.Dtos;

public class TransactionRequest
{
    public string? ReceiverAccount { get; set; }
    public string? SenderAccount { get; set; } = "";
    public decimal Amount { get; set; }
}

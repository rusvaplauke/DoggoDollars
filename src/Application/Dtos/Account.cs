namespace Application.Dtos;

public class Account
{
    public string Id { get; set; } = "";
    public int UserId { get; set; }
    public int TypeId { get; set; }
    public decimal Balance { get; set; } = 0;
}

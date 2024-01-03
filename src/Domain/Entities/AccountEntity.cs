namespace Domain.Entities;

public class AccountEntity
{
    public string Id { get; set; } = "";
    public int UserId { get; set; }
    public int TypeId { get; set; }
    public decimal Balance { get; set; } = 0;
    public Boolean IsDeleted { get; set; } = false;
}

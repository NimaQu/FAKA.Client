namespace FAKA.Client.Models;

public class AssignedKey : BaseEntity
{
    public string? Content { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }
    
    public string? UserId { get; set; }
}
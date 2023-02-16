using System.Runtime.Serialization;

namespace FAKA.Client.Models;

public class Order : BaseEntity
{
    public string? AccessCode { get; set; }
    public int Quantity { get; set; }
    public string Email { get; set; } = null!;

    public decimal Amount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public int ProductId { get; set; }

    public string? UserId { get; set; }

    public List<AssignedKey>? AssignedKeys { get; set; }
}

public enum OrderStatus
{
    [EnumMember(Value = "pending")] Pending,
    [EnumMember(Value = "paid")] Paid,
    [EnumMember(Value = "completed")] Completed,
    [EnumMember(Value = "cancelled")] Canceled
}
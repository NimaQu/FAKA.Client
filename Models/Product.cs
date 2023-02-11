namespace FAKA.Client.Models;

public class ProductResponse : BaseResponse
{
    public Product? Data { get; set; }
}

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool IsEnabled { get; set; } = true;
    public bool IsHidden { get; set; } = false;
    public int Stock { get; set; }
    public int ProductGroupId { get; set; }

    public List<Order> Orders { get; set; }

    public List<Key> Keys { get; set; }
}
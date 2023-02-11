namespace FAKA.Client.Models;



public class ProductGroupResponse : BaseResponse
{
    public List<ProductGroup>? Data { get; set; }
}
public class ProductGroup : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Product> Products { get; set; }
}
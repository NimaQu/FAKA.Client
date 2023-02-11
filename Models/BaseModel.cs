namespace FAKA.Client.Models;

public class BaseResponse
{
    public int code { get; set; }
    public string? message { get; set; }
}

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
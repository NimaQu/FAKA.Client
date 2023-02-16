using System.ComponentModel.DataAnnotations;
using FAKA.Client.Models;

namespace FAKA.Client.Auth;

public class UserRegister
{
    [Required(ErrorMessage = "用户名不能为空")]
    [StringLength(16, ErrorMessage = "用户名最短为4位，最长16位", MinimumLength = 4)]
    [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "用户名只能包含字母、数字和下划线及连字符")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "邮件地址不能为空")]
    [EmailAddress(ErrorMessage = "邮件地址格式不正确")]
    public string Email { get; set; }
    [Required(ErrorMessage = "密码不能为空")]
    [StringLength(128, ErrorMessage = "密码最少为8位数", MinimumLength = 8)]
    [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,}$", ErrorMessage = "密码必须包含大小写字母、数字和特殊字符")]
    public string Password { get; set; }
    
    [Required]
    [Compare(nameof(Password), ErrorMessage = "两次输入的密码不一致")]
    public string Password2 { get; set; }
}

public class UserLogin
{   
    [Required(ErrorMessage = "用户名不能为空")]
    public string Username { get; set; }
    [Required(ErrorMessage = "密码不能为空")]
    public string Password { get; set; }
}

public class UserLoginResponse : BaseResponse
{
    public string? Data { get; set; }
}

public class TokenDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}

public class RegisterResponse : BaseResponse
{
    public string? Data { get; set; }
}
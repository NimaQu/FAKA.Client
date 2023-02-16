using Blazored.LocalStorage;
using FAKA.Client.Models;

namespace FAKA.Client.Auth;

public interface ITokenService
{
    Task<TokenDto> GetToken();
    Task RemoveToken();
    Task SetToken(TokenDto tokenDTO);
}
 
public class TokenService : ITokenService
{
    private readonly ILocalStorageService _localStorageService;
 
    public TokenService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
 
    public async Task SetToken(TokenDto tokenDTO)
    {
        await _localStorageService.SetItemAsync("token", tokenDTO);
    }
 
    public async Task<TokenDto> GetToken()
    {
        return await _localStorageService.GetItemAsync<TokenDto>("token");
    }
 
    public async Task RemoveToken()
    {
        await _localStorageService.RemoveItemAsync("token");
    }
}
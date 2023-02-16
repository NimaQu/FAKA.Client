using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace FAKA.Client.Auth;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ITokenService tokenService;
 
    public CustomAuthenticationStateProvider(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }
 
    public void StateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
 
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenDTO = await tokenService.GetToken();
        var identity = string.IsNullOrEmpty(tokenDTO?.Token) || tokenDTO?.Expiration < DateTime.Now
            ? new ClaimsIdentity()
            : new ClaimsIdentity(ParseClaimsFromJwt(tokenDTO.Token), "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
 
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }
 
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}



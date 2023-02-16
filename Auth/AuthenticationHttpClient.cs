using System.Net.Http.Json;

namespace FAKA.Client.Auth;

public class AuthenticationHttpClient
{
    private readonly ILogger<AuthenticationHttpClient> _logger;
    private readonly HttpClient _http;
    private readonly ITokenService _tokenService;
 
    public AuthenticationHttpClient(ILogger<AuthenticationHttpClient> logger,
        HttpClient http, ITokenService tokenService)
    {
        _logger = logger;
        _http = http;
        _tokenService = tokenService;
    }
 
    public async Task<RegisterResponse> RegisterUser(UserRegister userUserRegisterDto)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("/api/v1/public/Auth/register", userUserRegisterDto);
            var result = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            if (result is null)
            {
                throw new Exception("API 响应为空或不正确");
            }
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new RegisterResponse
            {
                code = 500,
                message = ex.Message
            };
        }
    }
    
    public async Task<UserLoginResponse> LoginUser(UserLogin userLoginDto)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("/api/v1/public/Auth/login", userLoginDto);
            var result = await response.Content.ReadFromJsonAsync<UserLoginResponse>();
            if (result is null)
            {
                throw new Exception("API 响应为空或不正确");
            }
            result.Data = response.Headers.GetValues("Authorization").FirstOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new UserLoginResponse
            {
                code = 500,
                message = ex.Message
            };
        }
    }
}
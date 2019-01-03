using Rasot.Service.Services.Authentications.Models;

namespace Rasot.Service.Services.Authentications
{
    public  interface IAuthenticationService
    {
        RegisterResponse Register(RegisterRequest registerRequest);
        LoginResponse Login(LoginRequest loginRequest);
    }
}

using Rasot.Service.Services.Authentications.Models;

namespace Rasot.Service.Services.Authentications
{
    public  interface IAuthenticationService
    {
        void Register(RegisterRequest registerRequest);
        void Login(LoginRequest loginRequest);
    }
}

using Rasot.Core.Domain.Customers;

namespace Rasot.Service.Services.Authentications.Models
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
      
    }
}

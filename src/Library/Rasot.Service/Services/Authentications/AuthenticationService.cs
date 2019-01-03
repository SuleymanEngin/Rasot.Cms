using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;
using Rasot.Service.Services.Authentications.Models;
using System.Linq;

namespace Rasot.Service.Services.Authentications
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<Customer> _customerRepository;
        public AuthenticationService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public virtual LoginResponse Login(LoginRequest loginRequest)
        {
            var loginResponse = new LoginResponse();

            if(string.IsNullOrEmpty(loginRequest.Email))
            {
                loginResponse.Errors.Add("Email address is not valid");
                return loginResponse;
            }
            if (string.IsNullOrEmpty(loginRequest.Password))
            {
                loginResponse.Errors.Add("Password is not valid");
                return loginResponse;
            }


            var item = _customerRepository.Table.FirstOrDefault(p => p.Email == loginRequest.Email && p.Password == loginRequest.Password);
            if (item != null)
            {
                loginResponse.ValidCustomer = item;
            }

            return loginResponse;
        }

        public virtual RegisterResponse Register(RegisterRequest registerRequest)
        {
            var registerResponse = new RegisterResponse();
            if (string.IsNullOrEmpty(registerRequest.Email))
            {
                registerResponse.Errors.Add("Email address is not valid");
                return registerResponse;
            }
            if (string.IsNullOrEmpty(registerRequest.Password))
            {
                registerResponse.Errors.Add("Password is not valid");
                return registerResponse;
            }

           

            var customer = new Customer();
            customer.Email = registerRequest.Email;
            customer.Password = registerRequest.Password;
           
            _customerRepository.Insert(customer);

            return registerResponse;
        }
    }
}

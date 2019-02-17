using Microsoft.AspNetCore.Http;
using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;
using Rasot.Service.Services.Authentications.Models;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using System;

namespace Rasot.Service.Services.Authentications
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticationService(IRepository<Customer> customerRepository, IHttpContextAccessor httpContextAccessor)
        {
            _customerRepository = customerRepository;
            _httpContextAccessor = httpContextAccessor;
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

        public Customer GetAuthentication()
        {

            var result = _httpContextAccessor.HttpContext.AuthenticateAsync("Authentication").Result;

            if (result?.Principal != null)
            {
                var email = result.Principal.FindFirst(claim => claim.Type == ClaimTypes.Email);


                return new Customer() { Email = email.Value };
            }
            return null;


        }

        public void LogOut()
        {
            _httpContextAccessor.HttpContext.SignOutAsync("Authentication");
        }

        public void SigIn(Customer customer)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, customer.Email));
            claims.Add(new Claim(ClaimTypes.Name, customer.Name));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var userIdentity = new ClaimsIdentity(claims, "Authentication");
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            var authenticationProperties = new AuthenticationProperties()
            {
                IsPersistent = true,
                IssuedUtc = DateTime.UtcNow

            };

            _httpContextAccessor.HttpContext.SignInAsync("Authentication", userPrincipal, authenticationProperties);

        }
    }
}

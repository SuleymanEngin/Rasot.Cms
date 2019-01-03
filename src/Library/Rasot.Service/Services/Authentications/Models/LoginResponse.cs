using Rasot.Core.Domain.Customers;
using System.Collections.Generic;

namespace Rasot.Service.Services.Authentications.Models
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            Errors = new List<string>();
        }
        public IList<string> Errors { get; set; }
        public bool Success => Errors.Count == 0;
        public Customer ValidCustomer { get; set; }
    }
}

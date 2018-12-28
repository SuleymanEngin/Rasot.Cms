using System.Collections.Generic;

namespace Rasot.Service.Services.Authentications.Models
{
    public class LoginResponse
    {
        public IList<string> Errors { get; set; }
        public bool Success => Errors.Count == 0;
    }
}

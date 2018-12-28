using System.Collections.Generic;

namespace Rasot.Service.Services.Authentications.Models
{
    public class RegisterResponse
    {
        public IList<string> Errors { get; set; }
        public bool Success => Errors.Count == 0;
    }
}

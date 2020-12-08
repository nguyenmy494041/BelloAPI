using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Account
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
    }
}

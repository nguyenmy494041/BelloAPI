using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Account
{
    class GetUserResult
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
    }
}

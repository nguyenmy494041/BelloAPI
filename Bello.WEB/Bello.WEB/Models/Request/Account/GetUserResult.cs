﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Account
{
    public class GetUserResult
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
    }
}

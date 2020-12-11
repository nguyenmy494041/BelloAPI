using Bello.DAL.Interface;
using Bello.Domain.Request.Account;
using Bello.Domain.Response.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Implement
{
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; }
        public string FullName { get; set; }
    }
}

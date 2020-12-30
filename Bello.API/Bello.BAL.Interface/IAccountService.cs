using Bello.Domain.Request.Account;
using Bello.Domain.Response.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.BAL.Interface
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginRequest request);
        Task<RegisterResult> Register(RegisterRequest request);
    }
}

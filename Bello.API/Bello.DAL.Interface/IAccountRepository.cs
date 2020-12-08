using Bello.Domain.Request.Account;
using Bello.Domain.Response.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Interface
{
    public interface IAccountRepository
    {
        Task<LoginResult> Login(LoginRequest request);
        Task<RegisterResult> Register(RegisterRequest request);
    }
}

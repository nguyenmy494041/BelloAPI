using Bello.BAL.Interface;
using Bello.Domain.Request.Account;
using Bello.Domain.Response.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.BAL.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountService accountService;
        public AccountService(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public Task<LoginResult> Login(LoginRequest request)
        {
            return accountService.Login(request);
        }

        public Task<RegisterResult> Register(RegisterRequest request)
        {
            return accountService.Register(request);
        }
    }
}

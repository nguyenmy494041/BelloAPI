using Bello.BAL.Interface;
using Bello.DAL.Interface;
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
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public Task<LoginResult> Login(LoginRequest request)
        {
            return accountRepository.Login(request);
        }

        public Task<RegisterResult> Register(RegisterRequest request)
        {
            return accountRepository.Register(request);
        }
    }
}

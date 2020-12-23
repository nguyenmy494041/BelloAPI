using Bello.DAL.Interface;
using Bello.Domain.Request.Account;
using Bello.Domain.Response.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace Bello.DAL.Implement
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<LoginResult> Login(LoginRequest request)
        {
            try
            {
                var result = new LoginResult()
                {
                    Message = "Something went wrong, please try again",
                    Success = false,
                    UserId = string.Empty
                };

                var siginResult = await signInManager.PasswordSignInAsync(request.Email, request.Password,true,false);

                if (siginResult.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(request.Email);
                    if (user != null)
                    {
                        result.Success = siginResult.Succeeded;
                        result.UserId = user.Id;
                        result.Message = "Login success";
                    }
                }
                return result;
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }

        }

        public async Task<RegisterResult> Register(RegisterRequest request)
        {
            var result = new RegisterResult()
            {
                Message = "something went wrong, please try again",
                Success = false
            };

            var user = new ApplicationUser()
            {

                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                Avatar = request.Avatar
            };
            

            var registerResult = await userManager.CreateAsync(user, request.Password);
            if (registerResult.Succeeded)
            {
                result.Message = "Register success";
                result.Success = registerResult.Succeeded;
            }
            return result;
        }
       
    }
}

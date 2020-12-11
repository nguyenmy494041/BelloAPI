using Bello.BAL.Interface;
using Bello.DAL.Implement;
using Bello.Domain.Request.Account;
using Bello.Domain.Response.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.API.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAccountService accountService;

        public AccountController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    RoleManager<IdentityRole> roleManager,
                                    IWebHostEnvironment webHostEnvironment,
                                    IAccountService accountService
                                    )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
            this.accountService = accountService;
        }
        
        [HttpPost]
        [Route("/api/account/login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await accountService.Login(request);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("/api/account/register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await accountService.Register(request);
            return Ok(result);
        }
        [HttpGet]
        [Route("/api/account/getuser")]
        public async Task<IActionResult> GetUser()
        {
            var user = await userManager.GetUserAsync(User);
            return Ok(user);
        }
    }
}


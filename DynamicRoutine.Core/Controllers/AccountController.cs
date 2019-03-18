using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DynamicRoutine.Core.Data.Repositories;
using DynamicRoutine.Core.Domain.Models.Account;
using DynamicRoutine.Core.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicRoutine.Core.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = _userRepository.Find(loginModel.UserName, loginModel.Password);

            if (user == null)
            {
                return Json(ServiceResult.Error("کاربری یافت نشد"));
            }
            else
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.FullName));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(2)
                });

                return Json(ServiceResult.Okay("کاربر با موفقیت لاگین شد"));
            }
            
        }
    }
}
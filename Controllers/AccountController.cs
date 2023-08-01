using CRUDSystem.Repository.AccountRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CRUDSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRUDSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Login(Account acc)
        {
            var account = _accountRepository.Find(acc.UserName, acc.Password);
            if (account == null)
                return View(account);

            ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claims.AddClaim(new Claim(ClaimTypes.Name, account.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Role, account.Role));

            ClaimsPrincipal principal = new ClaimsPrincipal(claims);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction(nameof(Index), nameof(Client));
        }
        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index), nameof(Client));
        }
    }
}

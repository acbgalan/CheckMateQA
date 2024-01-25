using Microsoft.AspNetCore.Mvc;

using CheckMateQA.Services.Interfaces;
using CheckMateQA.Models.DTO;
using CheckMateQA.Models;
using Microsoft.AspNetCore.Authorization;

namespace CheckMateQA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthentification _userAuthentification;

        public AccountController(IUserAuthentification userAuthentification)
        {
            _userAuthentification = userAuthentification;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }

            ServiceResponse result = await _userAuthentification.LoginAsync(loginDTO);

            if (result.Success)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationDTO registrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(registrationDTO);
            }

            registrationDTO.Role = string.IsNullOrWhiteSpace(registrationDTO.Role) ? "Guest" : registrationDTO.Role;

            ServiceResponse result = await _userAuthentification.RegisterAsync(registrationDTO);

            if (result.Success)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            ServiceResponse result = await _userAuthentification.LogoutAsync();

            if (result.Success)
            {
                TempData["success"] = result.Message;
            }
            else
            {
                TempData["error"] = result.Message;
            }

            return RedirectToAction("Index", "Home");
        }

    }
}

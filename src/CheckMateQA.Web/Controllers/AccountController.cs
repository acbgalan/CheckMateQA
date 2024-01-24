using Microsoft.AspNetCore.Mvc;

using CheckMateQA.Services.Interfaces;
using CheckMateQA.Models.DTO;
using CheckMateQA.Models;

namespace CheckMateQA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthentification _userAuthentification;

        public AccountController(IUserAuthentification userAuthentification)
        {
            _userAuthentification = userAuthentification;
        }


        public async Task<string> Register()
        {
            RegistrationDTO registration = new RegistrationDTO()
            {
                Name = "Carlos Blanco",
                Email = "cblanco@mail.com",
                Username = "cblanco",
                Password = "P@ssw0rd!",
                PasswordConfirm = "ssw0rd!",
                Role = "Administrator"
            };

            ServiceResponse result = await _userAuthentification.RegisterAsync(registration);

            if (result.Success)
            {
                return $"{DateTime.Now} - {result.Message}";
            }
            else
            {
                return $"{DateTime.Now} - {result.Message}";
            }
        }

    }
}

using CheckMateQA.Models;
using CheckMateQA.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.Services.Interfaces
{
    public interface IUserAuthentification
    {
        Task<ServiceResponse> LoginAsync(LoginDTO model);
        Task<ServiceResponse> RegisterAsync(RegistrationDTO model);
        Task<ServiceResponse> LogoutAsync();
    }
}

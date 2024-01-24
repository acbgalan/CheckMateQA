﻿using CheckMateQA.Models;
using CheckMateQA.Models.DTO;
using CheckMateQA.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.Servicess
{
    public class UserAuthentification : IUserAuthentification
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserAuthentification(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ServiceResponse> LoginAsync(LoginDTO model)
        {
            var srvResponse = new ServiceResponse();
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                srvResponse.Success = false;
                srvResponse.Message = "Usuario no válido";
                return srvResponse;
            }

            //we will match password
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                srvResponse.Success = false;
                srvResponse.Message = "Contraseña no válida";
                return srvResponse;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };

                foreach (var rol in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, rol));
                }

                srvResponse.Success = true;
                srvResponse.Message = "Sesión iniciada correctamente";
                return srvResponse;
            }
            else if (signInResult.IsLockedOut)
            {
                srvResponse.Success = false;
                srvResponse.Message = "Usuario bloqueado";
                return srvResponse;
            }
            else
            {
                srvResponse.Success = false;
                srvResponse.Message = "Error al iniciar sesión";
                return srvResponse;
            }
        }

        public async Task<ServiceResponse> LogoutAsync()
        {
            await _signInManager.SignOutAsync();

            return new ServiceResponse { Success = true, Message = "Sesión cerrada" };
        }

        public async Task<ServiceResponse> RegisterAsync(RegistrationDTO model)
        {
            var svrResponse = new ServiceResponse();
            var userExits = await _userManager.FindByNameAsync(model.Username);

            if (userExits != null)
            {
                svrResponse.Success = false;
                svrResponse.Message = "Usuario ya existe";
                return svrResponse;
            }

            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                svrResponse.Success = false;
                svrResponse.Message = "Error al crear usuario";
                return svrResponse;
            }

            //Role management
            if (string.IsNullOrEmpty(model.Role))
            {
                svrResponse.Success = false;
                svrResponse.Message = "Rol de usuario no especificado";
                return svrResponse;
            }

            //TODO: The role creation should be in a separate method
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = model.Role });
            }
            else
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            svrResponse.Success = true;
            svrResponse.Message = "Usuario registrado con exito";
            return svrResponse;
        }
    }
}

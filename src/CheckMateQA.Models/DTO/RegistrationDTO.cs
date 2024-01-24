using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.Models.DTO
{
    public class RegistrationDTO
    {
        [DisplayName("Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [DisplayName("Correo electrónico ")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        public string Username { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }

        [DisplayName("Confirmar contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string PasswordConfirm { get; set; }

        public string Role { get; set; }
    }
}

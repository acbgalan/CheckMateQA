using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.Models.DTO
{
    public class LoginDTO
    {
        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Username { get; set; }


        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }

    }
}

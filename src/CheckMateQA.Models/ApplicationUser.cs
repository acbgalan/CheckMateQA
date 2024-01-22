using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Nombre")]
        [StringLength(50, ErrorMessage = "El campo {0} soporta un máximo de {1} caracteres")]
        public string Name { get; set; }

        [DisplayName("Imagen de perfil")]
        [StringLength(36, ErrorMessage = "El campo {0} soporta un máximo de {1} caracteres")]
        public string ProfilePicture { get; set; }
    }
}

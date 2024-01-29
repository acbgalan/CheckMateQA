using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es un campo requerido")]
        [StringLength(50, ErrorMessage = "{0} tiene un tamaño máximo de {1} caracteres")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        [StringLength(50, ErrorMessage = "{0} es un campo requerido")]
        [DisplayName("Actividad")]
        public string Activity { get; set; }

        [StringLength(50, ErrorMessage = "{0} tiene un tamaño máximo de {1} caracteres")]
        [DisplayName("Razón social")]
        public string BusinessName { get; set; }

        [StringLength(25, ErrorMessage = "{0} tiene un tamaño máximo de {1} caracteres")]
        [DisplayName("CIF")]
        public string Cif { get; set; }

        [StringLength(250, ErrorMessage = "{0} tiene un tamaño máximo de {1} caracteres")]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        //Contact

        //Location
    }
}

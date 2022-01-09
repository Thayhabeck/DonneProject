using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonneProject.Models
{
    public class Funcao
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string NomeFuncao { get; set; }
    }
}

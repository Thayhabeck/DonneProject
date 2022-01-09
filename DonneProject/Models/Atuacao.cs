using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonneProject.Models
{
    public class Atuacao
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string NomeArea { get; set; }
    }
}

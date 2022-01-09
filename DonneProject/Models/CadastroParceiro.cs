using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonneProject.Models
{
    public class CadastroParceiro
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string RZsocial { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string cnpj { get; set; }
        [Required]
        public string email { get; set; }

        [Required]
        public int NomeAreaId { get; set; }
        public Funcao NomeArea { get; set; }
    }
}

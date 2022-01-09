using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonneProject.Models
{
    public class CadastroSobrev
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string endereco { get; set; }
        [Required]
        public string email { get; set; }

        [Required]
        public int NomeFuncaoId { get; set; }
        public Funcao NomeFuncao { get; set; }
    }
}

using DonneProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonneProject.Data
{
    public class DonneDbContext : DbContext
    {
        public DonneDbContext()
        {
        }

        public DonneDbContext(DbContextOptions<DonneDbContext> opt) : base(opt)
        {

        }

        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Atuacao> Atuacao { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<CadastroParceiro> Parceiro { get; set; }
        public DbSet<CadastroSobrev> Sobrevivente { get; set; }
    }
}

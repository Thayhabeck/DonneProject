using DonneProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonneProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)  //Essa classe adiciona valores padrão à tabela
        {
            using (var context = new DonneDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DonneDbContext>>()))
            {
                if (context.Funcao.Any())
                {
                    return;   // Já temm dados na tabela
                }
                context.Funcao.AddRange(
                    new Funcao { NomeFuncao = "Qualificação de Leads" },
                    new Funcao { NomeFuncao = "Vendas" },
                    new Funcao { NomeFuncao = "Suporte" }
                );

                context.Atuacao.AddRange(
                    new Atuacao { NomeArea = "Telefonia" },
                    new Atuacao { NomeArea = "Tecnologia" },
                    new Atuacao { NomeArea = "Varejo" },
                    new Atuacao { NomeArea = "Outra" }
                );
                context.SaveChanges();
            }
        }
    }
}

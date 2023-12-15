using IngressosAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IngressosAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new AppDbContext();
            context.Tipo.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Tipo> ObterCargaInicial()
        {
            return new List<Tipo>()
            {
                new Tipo() { Nome = "Estudante" },
                new Tipo() { Nome = "Promocional " },
                new Tipo() { Nome = "Geral" },
            };
        }
    }
}

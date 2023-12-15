using IngressosAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IngressosAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new AppDbContext();
            context.Categoria.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Categoria> ObterCargaInicial()
        {
            return new List<Categoria>()
            {
                new Categoria() { Descricao = "Teatro" },
                new Categoria() { Descricao = "Show " },
                new Categoria() { Descricao = "Festa" },
                new Categoria() { Descricao = "Esporte" },
                new Categoria() { Descricao = "Educação" },
            };
        }
    }
}

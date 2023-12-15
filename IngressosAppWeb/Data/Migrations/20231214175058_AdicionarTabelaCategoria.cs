using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IngressosAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaIngresso",
                columns: table => new
                {
                    CategoriasCategoriaId = table.Column<int>(type: "integer", nullable: false),
                    IngressosIngressoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaIngresso", x => new { x.CategoriasCategoriaId, x.IngressosIngressoId });
                    table.ForeignKey(
                        name: "FK_CategoriaIngresso_Categoria_CategoriasCategoriaId",
                        column: x => x.CategoriasCategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaIngresso_Ingresso_IngressosIngressoId",
                        column: x => x.IngressosIngressoId,
                        principalTable: "Ingresso",
                        principalColumn: "IngressoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaIngresso_IngressosIngressoId",
                table: "CategoriaIngresso",
                column: "IngressosIngressoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaIngresso");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}

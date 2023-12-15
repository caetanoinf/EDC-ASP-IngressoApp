using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IngressosAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaIngresso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    IngressoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeEvento = table.Column<string>(type: "text", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Localizacao = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ImagemUrl = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    QuantidadeDisponivel = table.Column<int>(type: "integer", nullable: false),
                    Disponivel = table.Column<bool>(type: "boolean", nullable: false),
                    IngressoEstudante = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.IngressoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresso");
        }
    }
}

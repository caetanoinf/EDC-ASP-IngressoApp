using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IngressosAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarIngresso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "IngressoEstudante",
                table: "Ingresso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Ingresso",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IngressoEstudante",
                table: "Ingresso",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

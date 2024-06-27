using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class FlagTipoDePrevisao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPrevisao",
                table: "HistoricoDeBuscas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPrevisao",
                table: "HistoricoDeBuscas");
        }
    }
}

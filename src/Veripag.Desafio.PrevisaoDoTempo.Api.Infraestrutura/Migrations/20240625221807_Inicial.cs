using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoDeBuscas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataBusca = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CidadePesquisada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDeBuscas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrevisaoAtual",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Umidade = table.Column<double>(type: "float", nullable: false),
                    DescricaoTempo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VelocidadeVento = table.Column<double>(type: "float", nullable: false),
                    HistoricoBuscaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisaoAtual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisaoAtual_HistoricoDeBuscas_HistoricoBuscaId",
                        column: x => x.HistoricoBuscaId,
                        principalTable: "HistoricoDeBuscas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrevisaoEstendidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Umidade = table.Column<double>(type: "float", nullable: false),
                    DescricaoTempo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VelocidadeVento = table.Column<double>(type: "float", nullable: false),
                    HistoricoBuscaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevisaoEstendidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrevisaoEstendidas_HistoricoDeBuscas_HistoricoBuscaId",
                        column: x => x.HistoricoBuscaId,
                        principalTable: "HistoricoDeBuscas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevisaoAtual_HistoricoBuscaId",
                table: "PrevisaoAtual",
                column: "HistoricoBuscaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevisaoEstendidas_HistoricoBuscaId",
                table: "PrevisaoEstendidas",
                column: "HistoricoBuscaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrevisaoAtual");

            migrationBuilder.DropTable(
                name: "PrevisaoEstendidas");

            migrationBuilder.DropTable(
                name: "HistoricoDeBuscas");
        }
    }
}

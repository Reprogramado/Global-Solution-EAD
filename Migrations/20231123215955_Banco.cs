using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GS.Migrations
{
    /// <inheritdoc />
    public partial class Banco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    BeneficiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RedeAtendimento = table.Column<int>(type: "int", nullable: false),
                    UsoSubstancias = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.BeneficiarioId);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especializacao = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    AtendimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LocalDor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Fator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.AtendimentoId);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentosBeneficiarios",
                columns: table => new
                {
                    AtendimentoId = table.Column<int>(type: "int", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosBeneficiarios", x => new { x.BeneficiarioId, x.AtendimentoId });
                    table.ForeignKey(
                        name: "FK_AtendimentosBeneficiarios_Atendimentos_AtendimentoId",
                        column: x => x.AtendimentoId,
                        principalTable: "Atendimentos",
                        principalColumn: "AtendimentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentosBeneficiarios_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "BeneficiarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_MedicoId",
                table: "Atendimentos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosBeneficiarios_AtendimentoId",
                table: "AtendimentosBeneficiarios",
                column: "AtendimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentosBeneficiarios");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}

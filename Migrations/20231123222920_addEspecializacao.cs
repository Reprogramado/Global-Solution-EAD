using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GS.Migrations
{
    /// <inheritdoc />
    public partial class addEspecializacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Especializacao",
                table: "Medicos",
                newName: "Especial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Especial",
                table: "Medicos",
                newName: "Especializacao");
        }
    }
}

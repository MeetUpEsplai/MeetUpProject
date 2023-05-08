using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetUp.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenciaFoto",
                table: "Usuarios",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaFotoPrincipal",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenciaFoto",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ReferenciaFotoPrincipal",
                table: "Events");
        }
    }
}

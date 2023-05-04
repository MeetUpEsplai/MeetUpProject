using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetUp.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Events_IdEvento",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Chats_ChatId",
                table: "Mensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Usuarios_UsuarioId",
                table: "Mensajes");

            migrationBuilder.DropColumn(
                name: "IdChat",
                table: "Mensajes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Mensajes");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "Fotos");

            migrationBuilder.RenameColumn(
                name: "IdTipoReaccion",
                table: "UsuariosMensajes",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdTipoReaccion",
                table: "UsuariosComentarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdTipoReaccion",
                table: "UsuariosaEventos",
                newName: "UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "UsuarioSuscribeEvento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UsuarioSuscribeEvento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MensajeId",
                table: "UsuariosMensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoReaccionId",
                table: "UsuariosMensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComentarioId",
                table: "UsuariosComentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoReaccionId",
                table: "UsuariosComentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "UsuariosaEventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoReaccionId",
                table: "UsuariosaEventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEvento",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Events_IdEvento",
                table: "Comentarios",
                column: "IdEvento",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Chats_ChatId",
                table: "Mensajes",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Usuarios_UsuarioId",
                table: "Mensajes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Events_IdEvento",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Chats_ChatId",
                table: "Mensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_Usuarios_UsuarioId",
                table: "Mensajes");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropColumn(
                name: "MensajeId",
                table: "UsuariosMensajes");

            migrationBuilder.DropColumn(
                name: "TipoReaccionId",
                table: "UsuariosMensajes");

            migrationBuilder.DropColumn(
                name: "ComentarioId",
                table: "UsuariosComentarios");

            migrationBuilder.DropColumn(
                name: "TipoReaccionId",
                table: "UsuariosComentarios");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "UsuariosaEventos");

            migrationBuilder.DropColumn(
                name: "TipoReaccionId",
                table: "UsuariosaEventos");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "UsuariosMensajes",
                newName: "IdTipoReaccion");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "UsuariosComentarios",
                newName: "IdTipoReaccion");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "UsuariosaEventos",
                newName: "IdTipoReaccion");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Mensajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Mensajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdChat",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Mensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "Fotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdEvento",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Events_IdEvento",
                table: "Comentarios",
                column: "IdEvento",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Chats_ChatId",
                table: "Mensajes",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_Usuarios_UsuarioId",
                table: "Mensajes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

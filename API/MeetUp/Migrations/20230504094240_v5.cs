using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetUp.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Events_IdEvento",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_IdUsuario",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosaEventos_Events_IdEvento",
                table: "UsuariosaEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosaEventos_TipoReacciones_IdReaccion",
                table: "UsuariosaEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosaEventos_Usuarios_IdUsuario",
                table: "UsuariosaEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComentarios_Comentarios_IdComentario",
                table: "UsuariosComentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComentarios_TipoReacciones_IdReaccion",
                table: "UsuariosComentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComentarios_Usuarios_IdUsuario",
                table: "UsuariosComentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosMensajes_Mensajes_IdMensaje",
                table: "UsuariosMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosMensajes_TipoReacciones_IdReaccion",
                table: "UsuariosMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosMensajes_Usuarios_IdUsuario",
                table: "UsuariosMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSuscribeEvento_Events_IdEvento",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSuscribeEvento_Usuarios_IdUsuario",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSuscribeEvento_IdEvento",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSuscribeEvento_IdUsuario",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosMensajes_IdMensaje",
                table: "UsuariosMensajes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosMensajes_IdReaccion",
                table: "UsuariosMensajes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosMensajes_IdUsuario",
                table: "UsuariosMensajes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosComentarios_IdComentario",
                table: "UsuariosComentarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosComentarios_IdReaccion",
                table: "UsuariosComentarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosComentarios_IdUsuario",
                table: "UsuariosComentarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosaEventos_IdEvento",
                table: "UsuariosaEventos");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosaEventos_IdReaccion",
                table: "UsuariosaEventos");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosaEventos_IdUsuario",
                table: "UsuariosaEventos");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdEvento",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropColumn(
                name: "IdMensaje",
                table: "UsuariosMensajes");

            migrationBuilder.DropColumn(
                name: "IdReaccion",
                table: "UsuariosMensajes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "UsuariosMensajes");

            migrationBuilder.DropColumn(
                name: "IdComentario",
                table: "UsuariosComentarios");

            migrationBuilder.DropColumn(
                name: "IdReaccion",
                table: "UsuariosComentarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "UsuariosComentarios");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "UsuariosaEventos");

            migrationBuilder.DropColumn(
                name: "IdReaccion",
                table: "UsuariosaEventos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "UsuariosaEventos");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscribeEvento_EventoId",
                table: "UsuarioSuscribeEvento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscribeEvento_UsuarioId",
                table: "UsuarioSuscribeEvento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMensajes_MensajeId",
                table: "UsuariosMensajes",
                column: "MensajeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMensajes_TipoReaccionId",
                table: "UsuariosMensajes",
                column: "TipoReaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMensajes_UsuarioId",
                table: "UsuariosMensajes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComentarios_ComentarioId",
                table: "UsuariosComentarios",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComentarios_TipoReaccionId",
                table: "UsuariosComentarios",
                column: "TipoReaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComentarios_UsuarioId",
                table: "UsuariosComentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosaEventos_EventoId",
                table: "UsuariosaEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosaEventos_TipoReaccionId",
                table: "UsuariosaEventos",
                column: "TipoReaccionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosaEventos_UsuarioId",
                table: "UsuariosaEventos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EventoId",
                table: "Comentarios",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Events_EventoId",
                table: "Comentarios",
                column: "EventoId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosaEventos_Events_EventoId",
                table: "UsuariosaEventos",
                column: "EventoId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosaEventos_TipoReacciones_TipoReaccionId",
                table: "UsuariosaEventos",
                column: "TipoReaccionId",
                principalTable: "TipoReacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosaEventos_Usuarios_UsuarioId",
                table: "UsuariosaEventos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComentarios_Comentarios_ComentarioId",
                table: "UsuariosComentarios",
                column: "ComentarioId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComentarios_TipoReacciones_TipoReaccionId",
                table: "UsuariosComentarios",
                column: "TipoReaccionId",
                principalTable: "TipoReacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComentarios_Usuarios_UsuarioId",
                table: "UsuariosComentarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosMensajes_Mensajes_MensajeId",
                table: "UsuariosMensajes",
                column: "MensajeId",
                principalTable: "Mensajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosMensajes_TipoReacciones_TipoReaccionId",
                table: "UsuariosMensajes",
                column: "TipoReaccionId",
                principalTable: "TipoReacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosMensajes_Usuarios_UsuarioId",
                table: "UsuariosMensajes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSuscribeEvento_Events_EventoId",
                table: "UsuarioSuscribeEvento",
                column: "EventoId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSuscribeEvento_Usuarios_UsuarioId",
                table: "UsuarioSuscribeEvento",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Events_EventoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosaEventos_Events_EventoId",
                table: "UsuariosaEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosaEventos_TipoReacciones_TipoReaccionId",
                table: "UsuariosaEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosaEventos_Usuarios_UsuarioId",
                table: "UsuariosaEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComentarios_Comentarios_ComentarioId",
                table: "UsuariosComentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComentarios_TipoReacciones_TipoReaccionId",
                table: "UsuariosComentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComentarios_Usuarios_UsuarioId",
                table: "UsuariosComentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosMensajes_Mensajes_MensajeId",
                table: "UsuariosMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosMensajes_TipoReacciones_TipoReaccionId",
                table: "UsuariosMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosMensajes_Usuarios_UsuarioId",
                table: "UsuariosMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSuscribeEvento_Events_EventoId",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSuscribeEvento_Usuarios_UsuarioId",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSuscribeEvento_EventoId",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSuscribeEvento_UsuarioId",
                table: "UsuarioSuscribeEvento");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosMensajes_MensajeId",
                table: "UsuariosMensajes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosMensajes_TipoReaccionId",
                table: "UsuariosMensajes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosMensajes_UsuarioId",
                table: "UsuariosMensajes");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosComentarios_ComentarioId",
                table: "UsuariosComentarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosComentarios_TipoReaccionId",
                table: "UsuariosComentarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosComentarios_UsuarioId",
                table: "UsuariosComentarios");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosaEventos_EventoId",
                table: "UsuariosaEventos");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosaEventos_TipoReaccionId",
                table: "UsuariosaEventos");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosaEventos_UsuarioId",
                table: "UsuariosaEventos");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_EventoId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "UsuarioSuscribeEvento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "UsuarioSuscribeEvento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMensaje",
                table: "UsuariosMensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReaccion",
                table: "UsuariosMensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "UsuariosMensajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdComentario",
                table: "UsuariosComentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReaccion",
                table: "UsuariosComentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "UsuariosComentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "UsuariosaEventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReaccion",
                table: "UsuariosaEventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "UsuariosaEventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscribeEvento_IdEvento",
                table: "UsuarioSuscribeEvento",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscribeEvento_IdUsuario",
                table: "UsuarioSuscribeEvento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMensajes_IdMensaje",
                table: "UsuariosMensajes",
                column: "IdMensaje");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMensajes_IdReaccion",
                table: "UsuariosMensajes",
                column: "IdReaccion");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosMensajes_IdUsuario",
                table: "UsuariosMensajes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComentarios_IdComentario",
                table: "UsuariosComentarios",
                column: "IdComentario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComentarios_IdReaccion",
                table: "UsuariosComentarios",
                column: "IdReaccion");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComentarios_IdUsuario",
                table: "UsuariosComentarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosaEventos_IdEvento",
                table: "UsuariosaEventos",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosaEventos_IdReaccion",
                table: "UsuariosaEventos",
                column: "IdReaccion");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosaEventos_IdUsuario",
                table: "UsuariosaEventos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdEvento",
                table: "Comentarios",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Events_IdEvento",
                table: "Comentarios",
                column: "IdEvento",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosaEventos_Events_IdEvento",
                table: "UsuariosaEventos",
                column: "IdEvento",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosaEventos_TipoReacciones_IdReaccion",
                table: "UsuariosaEventos",
                column: "IdReaccion",
                principalTable: "TipoReacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosaEventos_Usuarios_IdUsuario",
                table: "UsuariosaEventos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComentarios_Comentarios_IdComentario",
                table: "UsuariosComentarios",
                column: "IdComentario",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComentarios_TipoReacciones_IdReaccion",
                table: "UsuariosComentarios",
                column: "IdReaccion",
                principalTable: "TipoReacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComentarios_Usuarios_IdUsuario",
                table: "UsuariosComentarios",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosMensajes_Mensajes_IdMensaje",
                table: "UsuariosMensajes",
                column: "IdMensaje",
                principalTable: "Mensajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosMensajes_TipoReacciones_IdReaccion",
                table: "UsuariosMensajes",
                column: "IdReaccion",
                principalTable: "TipoReacciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosMensajes_Usuarios_IdUsuario",
                table: "UsuariosMensajes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSuscribeEvento_Events_IdEvento",
                table: "UsuarioSuscribeEvento",
                column: "IdEvento",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSuscribeEvento_Usuarios_IdUsuario",
                table: "UsuarioSuscribeEvento",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

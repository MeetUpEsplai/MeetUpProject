using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetUp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoReacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emoji = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReacciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUsuario",
                columns: table => new
                {
                    ChatsId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsuario", x => new { x.ChatsId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_ChatUsuario_Chats_ChatsId",
                        column: x => x.ChatsId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadProxima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChat = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensajes_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensajes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdEvento = table.Column<int>(type: "int", nullable: true),
                    IdComentarioPadre = table.Column<int>(type: "int", nullable: true),
                    ComentarioPadreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Comentarios_ComentarioPadreId",
                        column: x => x.ComentarioPadreId,
                        principalTable: "Comentarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_Events_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtiquetaEvento",
                columns: table => new
                {
                    EtiquetasId = table.Column<int>(type: "int", nullable: false),
                    EventosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaEvento", x => new { x.EtiquetasId, x.EventosId });
                    table.ForeignKey(
                        name: "FK_EtiquetaEvento_Etiquetas_EtiquetasId",
                        column: x => x.EtiquetasId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaEvento_Events_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Events_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosaEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoReaccion = table.Column<int>(type: "int", nullable: false),
                    IdReaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosaEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosaEventos_Events_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosaEventos_TipoReacciones_IdReaccion",
                        column: x => x.IdReaccion,
                        principalTable: "TipoReacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosaEventos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSuscribeEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSuscribeEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSuscribeEvento_Events_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioSuscribeEvento_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosMensajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMensaje = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoReaccion = table.Column<int>(type: "int", nullable: false),
                    IdReaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosMensajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosMensajes_Mensajes_IdMensaje",
                        column: x => x.IdMensaje,
                        principalTable: "Mensajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosMensajes_TipoReacciones_IdReaccion",
                        column: x => x.IdReaccion,
                        principalTable: "TipoReacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosMensajes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosComentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComentario = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoReaccion = table.Column<int>(type: "int", nullable: false),
                    IdReaccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosComentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosComentarios_Comentarios_IdComentario",
                        column: x => x.IdComentario,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosComentarios_TipoReacciones_IdReaccion",
                        column: x => x.IdReaccion,
                        principalTable: "TipoReacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosComentarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsuario_UsuariosId",
                table: "ChatUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ComentarioPadreId",
                table: "Comentarios",
                column: "ComentarioPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdEvento",
                table: "Comentarios",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdUsuario",
                table: "Comentarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaEvento_EventosId",
                table: "EtiquetaEvento",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UsuarioId",
                table: "Events",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_EventoId",
                table: "Fotos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_ChatId",
                table: "Mensajes",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_UsuarioId",
                table: "Mensajes",
                column: "UsuarioId");

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
                name: "IX_UsuarioSuscribeEvento_IdEvento",
                table: "UsuarioSuscribeEvento",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSuscribeEvento_IdUsuario",
                table: "UsuarioSuscribeEvento",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUsuario");

            migrationBuilder.DropTable(
                name: "EtiquetaEvento");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "UsuariosaEventos");

            migrationBuilder.DropTable(
                name: "UsuariosComentarios");

            migrationBuilder.DropTable(
                name: "UsuariosMensajes");

            migrationBuilder.DropTable(
                name: "UsuarioSuscribeEvento");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "TipoReacciones");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

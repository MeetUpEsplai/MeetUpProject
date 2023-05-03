﻿// <auto-generated />
using System;
using MeetUp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetUp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230502112752_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatUsuario", b =>
                {
                    b.Property<int>("ChatsId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("ChatsId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("ChatUsuario");
                });

            modelBuilder.Entity("EtiquetaEvento", b =>
                {
                    b.Property<int>("EtiquetasId")
                        .HasColumnType("int");

                    b.Property<int>("EventosId")
                        .HasColumnType("int");

                    b.HasKey("EtiquetasId", "EventosId");

                    b.HasIndex("EventosId");

                    b.ToTable("EtiquetaEvento");
                });

            modelBuilder.Entity("MeetUp.Modelos.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("MeetUp.Modelos.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComentarioPadreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdComentarioPadre")
                        .HasColumnType("int");

                    b.Property<int?>("IdEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComentarioPadreId");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.Etiqueta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("MeetUp.Modelos.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CiudadProxima")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coordenadas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MeetUp.Modelos.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("MeetUp.Modelos.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChat")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("MeetUp.Modelos.TipoReaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Emoji")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoReacciones");
                });

            modelBuilder.Entity("MeetUp.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaComentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdComentario")
                        .HasColumnType("int");

                    b.Property<int>("IdReaccion")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoReaccion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdComentario");

                    b.HasIndex("IdReaccion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuariosComentarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdReaccion")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoReaccion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdReaccion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuariosaEventos");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaMensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdMensaje")
                        .HasColumnType("int");

                    b.Property<int>("IdReaccion")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoReaccion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMensaje");

                    b.HasIndex("IdReaccion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuariosMensajes");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioSuscribeEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuarioSuscribeEvento");
                });

            modelBuilder.Entity("ChatUsuario", b =>
                {
                    b.HasOne("MeetUp.Modelos.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EtiquetaEvento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Etiqueta", null)
                        .WithMany()
                        .HasForeignKey("EtiquetasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Comentario", b =>
                {
                    b.HasOne("MeetUp.Modelos.Comentario", "ComentarioPadre")
                        .WithMany("ComentariosHijos")
                        .HasForeignKey("ComentarioPadreId");

                    b.HasOne("MeetUp.Modelos.Evento", "Evento")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdEvento");

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ComentarioPadre");

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.Evento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("EventosCreados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.Foto", b =>
                {
                    b.HasOne("MeetUp.Modelos.Evento", "Evento")
                        .WithMany("Fotos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("MeetUp.Modelos.Mensaje", b =>
                {
                    b.HasOne("MeetUp.Modelos.Chat", "Chat")
                        .WithMany("Mensaje")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("Mensajes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaComentario", b =>
                {
                    b.HasOne("MeetUp.Modelos.Comentario", "Comentario")
                        .WithMany("Reacciones")
                        .HasForeignKey("IdComentario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.TipoReaccion", "TipoReaccion")
                        .WithMany("ReaccionesComentarios")
                        .HasForeignKey("IdReaccion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("ReaccionesComentarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comentario");

                    b.Navigation("TipoReaccion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaEvento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Evento", "Evento")
                        .WithMany("Reacciones")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.TipoReaccion", "TipoReaccion")
                        .WithMany("ReaccionesEventos")
                        .HasForeignKey("IdReaccion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("ReaccionesEventos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("TipoReaccion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaMensaje", b =>
                {
                    b.HasOne("MeetUp.Modelos.Mensaje", "Mensaje")
                        .WithMany("Reacciones")
                        .HasForeignKey("IdMensaje")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.TipoReaccion", "TipoReaccion")
                        .WithMany("ReaccionesMensajes")
                        .HasForeignKey("IdReaccion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("ReaccionesMensajes")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mensaje");

                    b.Navigation("TipoReaccion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioSuscribeEvento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Evento", "Evento")
                        .WithMany("UsuariosSuscritos")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("EventosSuscritos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.Chat", b =>
                {
                    b.Navigation("Mensaje");
                });

            modelBuilder.Entity("MeetUp.Modelos.Comentario", b =>
                {
                    b.Navigation("ComentariosHijos");

                    b.Navigation("Reacciones");
                });

            modelBuilder.Entity("MeetUp.Modelos.Evento", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Fotos");

                    b.Navigation("Reacciones");

                    b.Navigation("UsuariosSuscritos");
                });

            modelBuilder.Entity("MeetUp.Modelos.Mensaje", b =>
                {
                    b.Navigation("Reacciones");
                });

            modelBuilder.Entity("MeetUp.Modelos.TipoReaccion", b =>
                {
                    b.Navigation("ReaccionesComentarios");

                    b.Navigation("ReaccionesEventos");

                    b.Navigation("ReaccionesMensajes");
                });

            modelBuilder.Entity("MeetUp.Modelos.Usuario", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("EventosCreados");

                    b.Navigation("EventosSuscritos");

                    b.Navigation("Mensajes");

                    b.Navigation("ReaccionesComentarios");

                    b.Navigation("ReaccionesEventos");

                    b.Navigation("ReaccionesMensajes");
                });
#pragma warning restore 612, 618
        }
    }
}

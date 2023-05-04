﻿// <auto-generated />
using System;
using MeetUp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetUp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<int?>("EventoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComentarioPadreId");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Coordenadas")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

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

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

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

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaComentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComentarioId")
                        .HasColumnType("int");

                    b.Property<int>("TipoReaccionId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComentarioId");

                    b.HasIndex("TipoReaccionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosComentarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoReaccionId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("TipoReaccionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosaEventos");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioReaccionaMensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MensajeId")
                        .HasColumnType("int");

                    b.Property<int>("TipoReaccionId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MensajeId");

                    b.HasIndex("TipoReaccionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosMensajes");
                });

            modelBuilder.Entity("MeetUp.Modelos.UsuarioSuscribeEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

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
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioId")
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
                        .HasForeignKey("ComentarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.TipoReaccion", "TipoReaccion")
                        .WithMany("ReaccionesComentarios")
                        .HasForeignKey("TipoReaccionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("ReaccionesComentarios")
                        .HasForeignKey("UsuarioId")
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
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.TipoReaccion", "TipoReaccion")
                        .WithMany("ReaccionesEventos")
                        .HasForeignKey("TipoReaccionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("ReaccionesEventos")
                        .HasForeignKey("UsuarioId")
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
                        .HasForeignKey("MensajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.TipoReaccion", "TipoReaccion")
                        .WithMany("ReaccionesMensajes")
                        .HasForeignKey("TipoReaccionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("ReaccionesMensajes")
                        .HasForeignKey("UsuarioId")
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
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Usuario", "Usuario")
                        .WithMany("EventosSuscritos")
                        .HasForeignKey("UsuarioId")
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

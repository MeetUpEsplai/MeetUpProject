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

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Chat", b =>
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

            modelBuilder.Entity("MeetUp.Modelos.Entidades.ChatUsuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("ChatUsuarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComentarioId")
                        .HasColumnType("int");

                    b.Property<int?>("ComentarioPadreId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
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

                    b.HasIndex("ComentarioId");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Etiqueta", b =>
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

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Evento", b =>
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

                    b.Property<string>("ReferenciaFotoPrincipal")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.EventoEtiquetas", b =>
                {
                    b.Property<int>("EtiquetaId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("EtiquetaId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("EventoEtiquetas");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Foto", b =>
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

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Mensaje", b =>
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

            modelBuilder.Entity("MeetUp.Modelos.Entidades.TipoReaccion", b =>
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

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Usuario", b =>
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

                    b.Property<string>("ReferenciaFoto")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.UsuarioReaccionaComentario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("TipoReaccionId")
                        .HasColumnType("int");

                    b.Property<int>("ComentarioId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "TipoReaccionId", "ComentarioId");

                    b.HasIndex("TipoReaccionId");

                    b.ToTable("UsuariosComentarios");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.UsuarioReaccionaEvento", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("TipoReaccionId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "TipoReaccionId", "EventoId");

                    b.HasIndex("EventoId");

                    b.HasIndex("TipoReaccionId");

                    b.ToTable("UsuariosaEventos");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.UsuarioSuscribeEvento", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "EventoId");

                    b.HasIndex("EventoId");

                    b.ToTable("UsuarioSuscribeEvento");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.ChatUsuarios", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Chat", "Chat")
                        .WithMany("ChatUsuarios")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", "Usuario")
                        .WithMany("ChatUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Comentario", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Comentario", null)
                        .WithMany("ComentariosHijos")
                        .HasForeignKey("ComentarioId");

                    b.HasOne("MeetUp.Modelos.Entidades.Evento", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", null)
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Evento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", null)
                        .WithMany("Eventos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.EventoEtiquetas", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Etiqueta", "Etiqueta")
                        .WithMany("EventoEtiquetas")
                        .HasForeignKey("EtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Evento", "Evento")
                        .WithMany("EventoEtiquetas")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etiqueta");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Foto", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Evento", null)
                        .WithMany("Fotos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Mensaje", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Chat", null)
                        .WithMany("Mensajes")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", null)
                        .WithMany("Mensajes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.UsuarioReaccionaComentario", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.TipoReaccion", null)
                        .WithMany("UsuarioReaccionaComentarios")
                        .HasForeignKey("TipoReaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", null)
                        .WithMany("UsuarioReaccionaComentarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.UsuarioReaccionaEvento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Evento", null)
                        .WithMany("UsuarioReaccionaEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.TipoReaccion", null)
                        .WithMany("UsuarioReaccionaEventos")
                        .HasForeignKey("TipoReaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", null)
                        .WithMany("UsuarioReaccionaEventos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.UsuarioSuscribeEvento", b =>
                {
                    b.HasOne("MeetUp.Modelos.Entidades.Evento", "Evento")
                        .WithMany("UsuarioSuscribeEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetUp.Modelos.Entidades.Usuario", "Usuario")
                        .WithMany("UsuarioSuscribeEventos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Chat", b =>
                {
                    b.Navigation("ChatUsuarios");

                    b.Navigation("Mensajes");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Comentario", b =>
                {
                    b.Navigation("ComentariosHijos");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Etiqueta", b =>
                {
                    b.Navigation("EventoEtiquetas");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Evento", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("EventoEtiquetas");

                    b.Navigation("Fotos");

                    b.Navigation("UsuarioReaccionaEventos");

                    b.Navigation("UsuarioSuscribeEventos");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.TipoReaccion", b =>
                {
                    b.Navigation("UsuarioReaccionaComentarios");

                    b.Navigation("UsuarioReaccionaEventos");
                });

            modelBuilder.Entity("MeetUp.Modelos.Entidades.Usuario", b =>
                {
                    b.Navigation("ChatUsuarios");

                    b.Navigation("Comentarios");

                    b.Navigation("Eventos");

                    b.Navigation("Mensajes");

                    b.Navigation("UsuarioReaccionaComentarios");

                    b.Navigation("UsuarioReaccionaEventos");

                    b.Navigation("UsuarioSuscribeEventos");
                });
#pragma warning restore 612, 618
        }
    }
}

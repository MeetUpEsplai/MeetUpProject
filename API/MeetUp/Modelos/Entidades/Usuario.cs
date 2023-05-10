using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string? Apellido { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [StringLength(250)]
        public string? ReferenciaFoto { get; set; }

        public List<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
        public List<Evento> Eventos { get; set; } = new List<Evento>();
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public List<UsuarioSuscribeEvento> UsuarioSuscribeEventos { get; set; } = new List<UsuarioSuscribeEvento>();
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public List<UsuarioReaccionaComentario> UsuarioReaccionaComentarios { get; set; } = new List<UsuarioReaccionaComentario>();
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public List<UsuarioReaccionaEvento> UsuarioReaccionaEventos { get; set; } = new List<UsuarioReaccionaEvento>();
        public List<ChatUsuarios> ChatUsuarios { get; set; } = new List<ChatUsuarios>();


        public void AddModelInfo(UsuarioViewModel model)
        {
            Nombre = model.Nombre;
            Apellido = model.Apellido;
            Email = model.Email;
            Password = model.Contrasena;
            FechaNacimiento = model.FechaNacimiento;
            ReferenciaFoto = model.ReferenciaFoto;
        }
    }
}

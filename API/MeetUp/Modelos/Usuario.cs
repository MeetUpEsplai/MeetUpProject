using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
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

        public List<Mensaje>? Mensajes { get; set; }
        public List<Comentario>? Comentarios { get; set; }
        public List<Evento>? EventosCreados { get; set; }
        public List<UsuarioSuscribeEvento>? EventosSuscritos { get; set; }
        public List<Chat>? Chats { get; set; }
        public List<UsuarioReaccionaMensaje>? ReaccionesMensajes { get; set; }
        [InverseProperty("Usuario")]
        public List<UsuarioReaccionaEvento>? ReaccionesEventos { get; set; }
        public List<UsuarioReaccionaComentario>? ReaccionesComentarios { get; set; }


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

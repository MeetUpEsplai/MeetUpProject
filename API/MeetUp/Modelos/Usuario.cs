using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Mensaje>? Mensajes { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<Evento>? EventosCreados { get; set; }
        public ICollection<UsuarioSuscribeEvento>? EventosSuscritos { get; set; }
        public ICollection<Chat>? Chats { get; set; }
        public ICollection<UsuarioReaccionaMensaje>? ReaccionesMensajes { get; set; }
        [InverseProperty("Usuario")]
        public ICollection<UsuarioReaccionaEvento>? ReaccionesEventos { get; set; }
        public ICollection<UsuarioReaccionaComentario>? ReaccionesComentarios { get; set; }

    }
}

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

using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }

        public int IdChat { get; set; }
        public Chat Chat { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<UsuarioReaccionaMensaje>? Reacciones { get; set; }
    }
}

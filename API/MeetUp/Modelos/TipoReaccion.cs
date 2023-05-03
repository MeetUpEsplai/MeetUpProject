using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class TipoReaccion
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Emoji { get; set; }

        public ICollection<UsuarioReaccionaMensaje>? ReaccionesMensajes { get; set; }
        [InverseProperty("TipoReaccion")]
        public ICollection<UsuarioReaccionaEvento>? ReaccionesEventos { get; set; }
        public ICollection<UsuarioReaccionaComentario>? ReaccionesComentarios { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        [StringLength(500)]
        public string Texto { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public int? IdEvento { get; set; }
        [ForeignKey("IdEvento")]
        public Evento Evento { get; set; }

        public int? IdComentarioPadre { get; set; }
        public Comentario? ComentarioPadre { get; set; }
        [InverseProperty("ComentarioPadre")]
        public ICollection<Comentario>? ComentariosHijos { get; set; }
        [InverseProperty("Comentario")]
        public ICollection<UsuarioReaccionaComentario>? Reacciones { get; set; }
    }
}

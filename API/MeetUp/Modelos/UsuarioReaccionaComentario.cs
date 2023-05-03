using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioReaccionaComentario
    {
        [Key]
        public int Id { get; set; }

        public int IdComentario { get; set; }
        [ForeignKey("IdComentario")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Comentario Comentario { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }

        public int IdTipoReaccion { get; set; }
        [ForeignKey("IdReaccion")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TipoReaccion TipoReaccion { get; set; }
    }
}

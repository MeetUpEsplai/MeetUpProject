using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioReaccionaComentario
    {
        [Key]
        public int Id { get; set; }

        public int ComentarioId { get; set; }
        [ForeignKey("ComentarioId")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Comentario Comentario { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }

        public int TipoReaccionId { get; set; }
        [ForeignKey("TipoReaccionId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TipoReaccion TipoReaccion { get; set; }


        public void AddModelInfo(UsuarioReaccionaComentarioViewModel model)
        {
            ComentarioId = model.ComentarioId;
            UsuarioId = model.UsuarioId;
            TipoReaccionId = model.TipoReaccionId;
        }
    }
}

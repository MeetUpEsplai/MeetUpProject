using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
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

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }

        public int? EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento Evento { get; set; }

        public int? ComentarioPadreId { get; set; }
        public Comentario? ComentarioPadre { get; set; }
        [InverseProperty("ComentarioPadre")]
        public List<Comentario>? ComentariosHijos { get; set; }
        [InverseProperty("Comentario")]
        public List<UsuarioReaccionaComentario>? Reacciones { get; set; }

        public void AddModelInfo(ComentarioViewModel model)
        {
            FechaCreacion = model.FechaCreacion;
            Texto = model.Texto;
            UsuarioId = model.UsuarioId;
            EventoId = model.EventoId;
            ComentarioPadreId = model.ComentarioPadreId;
        }
    }
}

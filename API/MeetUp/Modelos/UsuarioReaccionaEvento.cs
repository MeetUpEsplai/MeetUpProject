using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioReaccionaEvento
    {
        [Key]
        public int Id { get; set; }

        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Evento Evento { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }

        public int TipoReaccionId { get; set; }
        [ForeignKey("TipoReaccionId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TipoReaccion TipoReaccion { get; set; }

        public void AddModelInfo(UsuarioReaccionaEventoViewModel model)
        {
            EventoId = model.EventoId;
            UsuarioId = model.UsuarioId;
            TipoReaccionId = model.TipoReaccionId;
        }
    }
}

using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioSuscribeEvento
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


        public void AddModelInfo(UsuarioSuscribeEventoViewModel model)
        {
            EventoId = model.EventoId;
            UsuarioId = model.UsuarioId;
        }
    }
}

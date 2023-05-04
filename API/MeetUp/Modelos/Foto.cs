using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos
{
    public class Foto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Referencia { get; set; }
        
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public void AddModelInfo(FotoViewModel model)
        {
            Referencia = model.Referencia;
            EventoId = model.EventoId;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class FotoViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Referencia { get; set; }

        public int EventoId { get; set; }
    }
}

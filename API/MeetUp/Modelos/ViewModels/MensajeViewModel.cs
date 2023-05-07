using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class MensajeViewModel
    {
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public int ChatId { get; set; }
        public int UsuarioId { get; set; }
    }
}

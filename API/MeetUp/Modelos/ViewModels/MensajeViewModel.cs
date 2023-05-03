using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class MensajeViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public int IdChat { get; set; }
        public int IdUsuario { get; set; }
    }
}

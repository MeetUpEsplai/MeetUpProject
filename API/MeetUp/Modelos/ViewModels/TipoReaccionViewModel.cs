using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class TipoReaccionViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Emoji { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class ChatViewModel
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<int> IdsUsuarios { get; set; }
    }
}

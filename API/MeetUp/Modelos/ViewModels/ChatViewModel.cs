using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class ChatViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacion { get; set; }

        public List<int> IdsUsuarios { get; set; }
    }
}

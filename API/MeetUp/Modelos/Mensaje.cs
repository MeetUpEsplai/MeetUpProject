using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        [StringLength(500)]
        public string Texto { get; set; }

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public ICollection<UsuarioReaccionaMensaje>? Reacciones { get; set; }

        public void AddModelInfo(MensajeViewModel model)
        {
            Fecha = model.Fecha;
            Texto = model.Texto;
            ChatId = model.ChatId;
            UsuarioId = model.UsuarioId;
        }
    }
}

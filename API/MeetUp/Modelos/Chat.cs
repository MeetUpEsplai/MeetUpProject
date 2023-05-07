using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        [InverseProperty("Chat")]
        public List<Mensaje>? Mensaje { get; set;}
        [InverseProperty("Chats")]
        public List<Usuario> Usuarios { get; set; }

        public void AddModelInfo(ChatViewModel model)
        {
            Nombre = model.Nombre;
            FechaCreacion = model.FechaCreacion;
        }
    }
}

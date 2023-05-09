using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }


        public List<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
        public List<ChatUsuarios> ChatUsuarios { get; set; } = new List<ChatUsuarios>();

        public void AddModelInfo(ChatViewModel model)
        {
            Nombre = model.Nombre;
            FechaCreacion = model.FechaCreacion;
        }
    }
}

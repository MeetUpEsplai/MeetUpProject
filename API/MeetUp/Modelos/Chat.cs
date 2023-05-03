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
        public ICollection<Mensaje>? Mensaje { get; set;}
        [InverseProperty("Chats")]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}

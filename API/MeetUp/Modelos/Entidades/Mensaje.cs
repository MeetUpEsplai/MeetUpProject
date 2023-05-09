using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.Entidades
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        [StringLength(500)]
        public string Texto { get; set; }

        public int ChatId { get; set; }
        public int UsuarioId { get; set; }
    }
}

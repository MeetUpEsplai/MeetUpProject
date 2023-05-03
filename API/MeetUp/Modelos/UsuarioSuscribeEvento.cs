using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioSuscribeEvento
    {
        [Key]
        public int Id { get; set; }

        public int IdEvento { get; set; }
        [ForeignKey("IdEvento")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Evento Evento { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }
    }
}

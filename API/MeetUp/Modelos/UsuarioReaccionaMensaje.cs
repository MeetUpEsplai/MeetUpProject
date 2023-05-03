using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioReaccionaMensaje
    {
        [Key]
        public int Id { get; set; }

        public int IdMensaje { get; set; }
        [ForeignKey("IdMensaje")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Mensaje Mensaje { get; set; }
        
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }
        
        public int IdTipoReaccion { get; set; }
        [ForeignKey("IdReaccion")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TipoReaccion TipoReaccion { get; set; }
    }
}

using MeetUp.Modelos.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class UsuarioReaccionaMensaje
    {
        [Key]
        public int Id { get; set; }

        public int MensajeId { get; set; }
        [ForeignKey("MensajeId")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Mensaje Mensaje { get; set; }
        
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Usuario Usuario { get; set; }
        
        public int TipoReaccionId { get; set; }
        [ForeignKey("TipoReaccionId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public TipoReaccion TipoReaccion { get; set; }


        public void AddModelInfo(UsuarioReaccionaMensajeViewModel model)
        {
            MensajeId = model.MensajeId;
            UsuarioId = model.UsuarioId;
            TipoReaccionId = model.TipoReaccionId;
        }
    }
}

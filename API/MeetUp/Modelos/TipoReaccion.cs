using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class TipoReaccion
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Emoji { get; set; }

        public List<UsuarioReaccionaMensaje>? ReaccionesMensajes { get; set; }
        [InverseProperty("TipoReaccion")]
        public List<UsuarioReaccionaEvento>? ReaccionesEventos { get; set; }
        public List<UsuarioReaccionaComentario>? ReaccionesComentarios { get; set; }


        public void AddModelInfo(TipoReaccionViewModel model)
        {
            Nombre = model.Nombre;
            Emoji = model.Emoji;
        }
    }
}

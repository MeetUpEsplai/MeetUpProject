using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
{
    public class TipoReaccion
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(250)]
        public string Emoji { get; set; }

        public List<UsuarioReaccionaComentario> UsuarioReaccionaComentarios { get; set; } = new List<UsuarioReaccionaComentario>();
        public List<UsuarioReaccionaEvento> UsuarioReaccionaEventos { get; set; } = new List<UsuarioReaccionaEvento>();


        public void AddModelInfo(TipoReaccionViewModel model)
        {
            Nombre = model.Nombre;
            Emoji = model.Emoji;
        }
    }
}

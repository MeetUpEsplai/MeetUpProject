using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class ComentarioViewModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string Texto { get; set; }

        public int IdUsuario { get; set; }
        public int? IdEvento { get; set; }

        public int? IdComentarioPadre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class ComentarioViewModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string Texto { get; set; }

        public int UsuarioId { get; set; }
        public int? EventoId { get; set; }

        public int? ComentarioPadreId { get; set; }
    }
}

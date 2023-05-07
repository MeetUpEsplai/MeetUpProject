using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class EventoViewModel
    {
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaEvento { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(100)]
        public string Coordenadas { get; set; }

        [StringLength(50)]
        public string CiudadProxima { get; set; }

        public int UsuarioId { get; set; }


        public List<int>? IdsEtiquetas { get; set; }
    }
}

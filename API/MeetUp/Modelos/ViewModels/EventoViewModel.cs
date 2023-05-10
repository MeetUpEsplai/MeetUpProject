using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class EventoViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        public string FechaEvento { get; set; }

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
        public string? ReferenciaFotoPrincipal { get; set; }

        public int UsuarioId { get; set; }
    }
}

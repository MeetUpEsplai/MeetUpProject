using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.ViewModels
{
    public class EventoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEvento { get; set; }
        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public string? Coordenadas { get; set; }

        public string? CiudadProxima { get; set; }

        public int IdUsuario { get; set; }
    }
}

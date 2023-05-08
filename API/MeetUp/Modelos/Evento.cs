using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }
        public DateTime FechaEvento { get; set; }
        [Precision(10, 2)]
        public decimal Precio { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(100)]
        public string? Coordenadas { get; set; }
        [StringLength(250)]
        public string? ReferenciaFotoPrincipal { get; set; }

        [StringLength(50)]
        public string? CiudadProxima { get; set; } 

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Foto>? Fotos { get; set; }
        public List<Comentario>? Comentarios { get; set; }
        public List<UsuarioSuscribeEvento>? UsuariosSuscritos { get; set; }
        [InverseProperty("Evento")]
        public List<UsuarioReaccionaEvento>? Reacciones { get; set; }
        public List<Etiqueta>? Etiquetas { get; set; }


        public void AddModelInfo(EventoViewModel model)
        {
            Nombre = model.Nombre;
            FechaEvento = model.FechaEvento;
            Precio = model.Precio;
            Descripcion = model.Descripcion;
            Coordenadas = model.Coordenadas;
            CiudadProxima = model.CiudadProxima;
            UsuarioId = model.UsuarioId;
            ReferenciaFotoPrincipal = model.ReferenciaFotoPrincipal;
        }
    }
}

using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
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

        public List<Foto> Fotos { get; set; } = new List<Foto>();
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public List<UsuarioSuscribeEvento> UsuarioSuscribeEventos { get; set; } = new List<UsuarioSuscribeEvento>();
        public List<UsuarioReaccionaEvento> UsuarioReaccionaEventos { get; set; } = new List<UsuarioReaccionaEvento>();
        public List<EventoEtiquetas> EventoEtiquetas { get; set; } = new List<EventoEtiquetas>();


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

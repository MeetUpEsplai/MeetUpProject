using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEvento { get; set; }
        [Precision(10, 2)]
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string? Coordenadas { get; set; }
        public string? CiudadProxima { get; set; } 

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Foto>? Fotos { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<UsuarioSuscribeEvento>? UsuariosSuscritos { get; set; }
        [InverseProperty("Evento")]
        public ICollection<UsuarioReaccionaEvento>? Reacciones { get; set; }
        public ICollection<Etiqueta>? Etiquetas { get; set; }
    }
}

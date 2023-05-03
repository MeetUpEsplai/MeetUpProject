using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos
{
    public class Etiqueta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public ICollection<Evento>? Eventos { get; set; }
    }
}

using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos.Entidades
{
    public class Etiqueta
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        public List<EventoEtiquetas> EventoEtiquetas { get; set; } = new List<EventoEtiquetas>();

        public void AddModelInfo(EtiquetaViewModel model)
        {
            Nombre = model.Nombre;
        }
    }
}

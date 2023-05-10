using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string FechaCreacion { get; set; }
        [StringLength(500)]
        public string Texto { get; set; }

        
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public int? ComentarioPadreId { get; set; }

        public List<Comentario> ComentariosHijos { get; set; } = new List<Comentario>();

        public void AddModelInfo(ComentarioViewModel model)
        {
            FechaCreacion = model.FechaCreacion;
            Texto = model.Texto;
            UsuarioId = model.UsuarioId;
            EventoId = model.EventoId;
            ComentarioPadreId = model.ComentarioPadreId;
        }
    }
}

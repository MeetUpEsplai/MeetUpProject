using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
{
    public class UsuarioSuscribeEvento
    {

        public int EventoId { get; set; }
        public int UsuarioId { get; set; }

    }
}

﻿using MeetUp.Modelos.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos
{
    public class Etiqueta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public List<Evento>? Eventos { get; set; }

        public void AddModelInfo(EtiquetaViewModel model)
        {
            Nombre = model.Nombre;
        }
    }
}
    
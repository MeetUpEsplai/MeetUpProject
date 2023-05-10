﻿using MeetUp.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetUp.Modelos.Entidades
{
    public class UsuarioReaccionaComentario
    {
        public int ComentarioId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoReaccionId { get; set; }
    }
}

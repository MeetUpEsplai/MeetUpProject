using MeetUp.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<Evento> Events { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<TipoReaccion> TipoReacciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioReaccionaComentario> UsuariosComentarios { get; private set; }
        public DbSet<UsuarioReaccionaEvento> UsuariosaEventos { get; set; }
        public DbSet<UsuarioReaccionaMensaje> UsuariosMensajes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MeetUp.Modelos.UsuarioSuscribeEvento>? UsuarioSuscribeEvento { get; set; }

    }
}

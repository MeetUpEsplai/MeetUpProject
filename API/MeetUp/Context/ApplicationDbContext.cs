using MeetUp.Modelos.Entidades;
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
        public DbSet<UsuarioSuscribeEvento> UsuarioSuscribeEvento { get; set; }
        public DbSet<EventoEtiquetas> EventoEtiquetas { get; set; }
        public DbSet<ChatUsuarios> ChatUsuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioSuscribeEvento>().HasKey(x => new { x.UsuarioId, x.EventoId });
            modelBuilder.Entity<UsuarioReaccionaComentario>().HasKey(x => new { x.UsuarioId, x.TipoReaccionId, x.ComentarioId });
            modelBuilder.Entity<UsuarioReaccionaEvento>().HasKey(x => new { x.UsuarioId, x.TipoReaccionId, x.EventoId });
            modelBuilder.Entity<ChatUsuarios>().HasKey(x => new { x.UsuarioId, x.ChatId });
            modelBuilder.Entity<EventoEtiquetas>().HasKey(x => new { x.EtiquetaId, x.EventoId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging();
        }
    }
}

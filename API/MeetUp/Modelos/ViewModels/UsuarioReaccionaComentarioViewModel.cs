namespace MeetUp.Modelos.ViewModels
{
    public class UsuarioReaccionaComentarioViewModel
    {
        public int Id { get; set; }
        public int ComentarioId { get; set; }

        public int UsuarioId { get; set; }

        public int TipoReaccionId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MeetUp.Modelos
{
    public class Foto
    {
        [Key]
        public int Id { get; set; }
        public string Referencia { get; set; }
        
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
    }
}

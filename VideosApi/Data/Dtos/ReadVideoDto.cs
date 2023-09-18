using System.ComponentModel.DataAnnotations;

namespace VideosApi.Data.Dtos
{
    public class ReadVideoDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime HoraConsulta { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;
using VideosApi.Models;

namespace VideosApi.Data.Dtos
{
    public class ReadVideoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime HoraConsulta { get; set; } = DateTime.Now;
    }
}

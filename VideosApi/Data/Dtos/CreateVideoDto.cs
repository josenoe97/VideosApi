using System.ComponentModel.DataAnnotations;

namespace VideosApi.Data.Dtos
{
    public class CreateVideoDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int CategoriaId { get; set; }
    }
}

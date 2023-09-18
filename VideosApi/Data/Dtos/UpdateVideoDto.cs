using System.ComponentModel.DataAnnotations;

namespace VideosApi.Data.Dtos
{
    public class UpdateVideoDto
    {
        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public string? Url { get; set; }
    }
}

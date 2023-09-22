using System.ComponentModel.DataAnnotations;

namespace VideosApi.Data.Dtos
{
    public class ReadCategoriaDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Cor { get; set; }
    }
}
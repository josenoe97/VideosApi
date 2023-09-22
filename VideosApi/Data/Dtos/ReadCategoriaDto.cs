using System.ComponentModel.DataAnnotations;

namespace VideosApi.Data.Dtos
{
    public class ReadCategoriaDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Cor { get; set; }
    }
}
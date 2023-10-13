using System.ComponentModel.DataAnnotations;

namespace VideosApi.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Nome deve ter entre 10 e 100 caracteres!")]
        public string Descricao { get; set; }

        [Required]
        public string Url { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}

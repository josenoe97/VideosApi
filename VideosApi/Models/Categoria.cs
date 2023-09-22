using System.ComponentModel.DataAnnotations;

namespace VideosApi.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Cor { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}

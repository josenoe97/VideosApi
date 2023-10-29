using Microsoft.AspNetCore.Identity;

namespace VideosApi.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }

        public Usuario() : base() { }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideosApi.Models;

namespace VideosApi.Data
{
    public class VideoContext : IdentityDbContext
    {
        public VideoContext(DbContextOptions<VideoContext> opts)
            :base(opts) { }
        
        public DbSet<Video> Videos { get; set; } 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

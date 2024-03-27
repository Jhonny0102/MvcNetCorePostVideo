using Microsoft.EntityFrameworkCore;
using MvcNetCorePostVideo.Models;

namespace MvcNetCorePostVideo.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) 
            :base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

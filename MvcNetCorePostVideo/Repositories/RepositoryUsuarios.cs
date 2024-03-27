using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcNetCorePostVideo.Data;
using MvcNetCorePostVideo.Models;
using System.Data;

namespace MvcNetCorePostVideo.Repositories
{
    public class RepositoryUsuarios
    {
        private UsuariosContext context;
        public RepositoryUsuarios(UsuariosContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await this.context.Usuarios.ToListAsync();
        }

        public async Task<int> GetNumeroUsuariosAsync()
        {
            return await this.context.Usuarios.CountAsync();
        }

        public async Task<List<Usuario>> GetGrupoUsuariosAsync(int posicion)
        {
            string sql = "SP_GRUPO_USUARIOS @posicion";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            var consulta = this.context.Usuarios.FromSqlRaw(sql, pamPosicion);
            return await consulta.ToListAsync();
        }

        public async Task<MixtoUsuarios> GetUsuariosFiltro(int posicion, int tipo)
        {
            string sql = "SP_GRUPO_USUARIOSFILTRO @posicion, @tipo, @registros out";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamOficio = new SqlParameter("@tipo", tipo);
            SqlParameter pamRegistros = new SqlParameter("@registros", -1);
            pamRegistros.Direction = ParameterDirection.Output;
            var consulta = this.context.Usuarios.FromSqlRaw(sql, pamPosicion, pamOficio, pamRegistros);
            List<Usuario> usuarios = await consulta.ToListAsync();
            int registros = (int)pamRegistros.Value;
            return new MixtoUsuarios
            {
                Registros = registros,
                UsuariosList = usuarios
            };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MvcNetCorePostVideo.Models;
using MvcNetCorePostVideo.Repositories;

namespace MvcNetCorePostVideo.Controllers
{
    public class UsuariosController : Controller
    {
        private RepositoryUsuarios repo;
        public UsuariosController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Usuarios()
        {
            List<Usuario> usuarios = await this.repo.GetUsuariosAsync();
            return View(usuarios);
        }

        public async Task<IActionResult> PaginacionUsuarios(int? posicion)
        {
            if (posicion == null)
            {
                posicion = 1;
            }
            int registros = await this.repo.GetNumeroUsuariosAsync();
            ViewData["REGISTROS"] = registros;
            List<Usuario> usuarios = await this.repo.GetGrupoUsuariosAsync(posicion.Value);
            return View(usuarios);
        }

        public async Task<IActionResult> UsuariosFiltro(int? posicion, int tipo)
        {
            if (posicion == null)
            {
                posicion = 1;
                return View();
            }
            else
            {
                MixtoUsuarios model = await this.repo.GetUsuariosFiltro(posicion.Value, tipo);
                ViewData["REGISTROS"] = model.Registros;
                ViewData["TIPO"] = tipo;
                return View(model.UsuariosList);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UsuariosFiltro(int tipo)
        {
            MixtoUsuarios model = await this.repo.GetUsuariosFiltro(1, tipo);
            ViewData["REGISTROS"] = model.Registros;
            ViewData["TIPO"] = tipo;
            return View(model.UsuariosList);
        }
    }
}

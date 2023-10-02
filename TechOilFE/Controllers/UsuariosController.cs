using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOilFE.ViewModels;

namespace TechOilFE.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public UsuariosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Usuarios()
        {
            return View();
        }

        public async Task<IActionResult> UsuariosAddPartial([FromBody] UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            if (usuario != null)
            {
                usuariosViewModel = usuario;
            }

            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml", usuariosViewModel);
        }
        public async Task<IActionResult> UsuariosUpdPartial([FromBody] UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            if (usuario != null)
            {
                usuariosViewModel = usuario;
            }

            return PartialView("~/Views/Usuarios/Partial/UsuariosUpdPartial.cshtml", usuariosViewModel);
        }
        public IActionResult GuardarUsuario(UsuarioDto usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PostToApi("Usuario/Rergister", usuario, token);
            return View("~/Views/Usuarios/Usuarios.cshtml");
        }
        public IActionResult EditarUsuario(UsuarioDto usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PutToApi("Usuario/"+usuario.CodUsuario.ToString(), usuario, token);
            return View("~/Views/Usuarios/Usuarios.cshtml");
        }

        [Route("Usuarios/EliminarUsuario/{valorCodUsuario}")]
        public IActionResult EliminarUsuario(string valorCodUsuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.DeleteToApi("Usuario/"+valorCodUsuario, token);
            return View("~/Views/Usuarios/Usuarios.cshtml");
        }
    }
}

using Data.DTOs;

namespace TechOilFE.ViewModels
{
    public class UsuariosViewModel
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public int CodRol { get; set; }
        public bool Activo { get; set; }

        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.CodUsuario = usuario.CodUsuario;
            usuariosViewModel.Nombre = usuario.Nombre;
            usuariosViewModel.Dni = usuario.Dni;
            usuariosViewModel.Email = usuario.Email;
            usuariosViewModel.Clave = usuario.Clave;
            usuariosViewModel.CodRol = usuario.CodRol;
            usuariosViewModel.Activo= usuario.Activo;
            return usuariosViewModel;
        }
    }
}

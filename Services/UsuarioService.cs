using ProvaMVVM.Models;

namespace ProvaMVVM.Services
{
    public class UsuarioService
    {
        UsuarioSingleton dbSingleton = UsuarioSingleton.Instancia;

        public void SalvarOuAtualizar(Usuario usuario)
        {
            dbSingleton.Usuario = usuario;
        }

        public Usuario Consultar()
        {
            return dbSingleton.Usuario;
        }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = dbSingleton.Usuario;

            if (usuario == null)
                return false;

            return usuario.Email == email && usuario.Senha == senha;
        }
    }
}

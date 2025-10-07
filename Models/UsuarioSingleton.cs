namespace ProvaMVVM.Models
{
    public sealed class UsuarioSingleton
    {
        private static UsuarioSingleton _instancia;

        public static UsuarioSingleton Instancia
        {
            get
            {
                return _instancia ?? (_instancia = new UsuarioSingleton());
            }
        }

        private UsuarioSingleton() { }
        public Usuario Usuario { get; set; }
    }
}

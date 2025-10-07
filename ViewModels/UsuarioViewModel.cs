using ProvaMVVM.Models;
using ProvaMVVM.Services;
using ProvaMVVM.Views;
using System.Windows.Input;

namespace ProvaMVVM.ViewModels
{
    public class UsuarioViewModel : BaseNotifyViewModel
    {
        UsuarioService usuarioService = new UsuarioService();

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _cpf;
        public string CPF
        {
            get { return _cpf; }
            set
            {
                _cpf = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dataNascimento = DateTime.Now;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set
            {
                _dataNascimento = value;
                OnPropertyChanged();
            }
        }

        public ICommand CadastrarCommand { get; set; }
        public ICommand IrParaCadastroCommand { get; set; }
        public ICommand VisualizarCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }
        public ICommand LoginCommand { get; set; }


        public UsuarioViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            IrParaCadastroCommand = new Command(IrParaCadastro);
            VisualizarCommand = new Command(Visualizar);
            ConsultarCommand = new Command(Consultar);
            LoginCommand = new Command(Login);
        }

        private void Cadastrar()
        {
            var usuario = new Usuario
            {
                Nome = Nome,
                CPF = CPF,
                Email = Email,
                Senha = Senha,
                DataNascimento = DataNascimento
            };
            usuarioService.SalvarOuAtualizar(usuario);
            App.Current.MainPage.DisplayAlert("Sucesso", "Cadastro salvo com sucesso!", "OK");

            Email = string.Empty;
            Senha = string.Empty;

            App.Current.MainPage.Navigation.PopAsync();
        }

        private async void IrParaCadastro()
        {
            Consultar();
            await App.Current.MainPage.Navigation.PushAsync(new CadastroView(this));
        }
        private async void Visualizar()
        {
            var usuario = usuarioService.Consultar();
            if (usuario != null)
            {
                string info = $"Nome: {usuario.Nome}\n" +
                              $"CPF: {usuario.CPF}\n" +
                              $"E-mail: {usuario.Email}\n" +
                              $"Data Nascimento: {usuario.DataNascimento:d}";
                await App.Current.MainPage.DisplayAlert("Informações do Usuário", info, "OK");
            }
        }

        private void Consultar()
        {
            var usuario = usuarioService.Consultar();
            if (usuario != null)
            {
                Nome = usuario.Nome;
                CPF = usuario.CPF;
                Email = usuario.Email;
                Senha = usuario.Senha;
                DataNascimento = usuario.DataNascimento;
            }
        }

        private async void Login()
        {
            bool valido = usuarioService.ValidarLogin(Email, Senha);
            if (valido)
            {
                await App.Current.MainPage.DisplayAlert("Bem-vindo!", "Login realizado com sucesso.", "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PrincipalView(this));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Erro", "E-mail ou senha incorretos.", "OK");
            }
        }
    }

}

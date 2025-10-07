using ProvaMVVM.ViewModels;

namespace ProvaMVVM.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();

        BindingContext = new UsuarioViewModel();
    }
}
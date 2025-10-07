using ProvaMVVM.ViewModels;

namespace ProvaMVVM.Views;

public partial class CadastroView : ContentPage
{
	public CadastroView(UsuarioViewModel usuarioViewModel)
	{
		InitializeComponent();

        BindingContext = usuarioViewModel;
    }

	public CadastroView()
	{
		InitializeComponent();
		BindingContext = new UsuarioViewModel();
	}
}
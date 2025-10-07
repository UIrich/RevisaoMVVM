using ProvaMVVM.Models;
using ProvaMVVM.Services;
using ProvaMVVM.ViewModels;

namespace ProvaMVVM.Views;

public partial class PrincipalView : ContentPage
{
	public PrincipalView(UsuarioViewModel usuarioViewModel)
	{
		InitializeComponent();

        BindingContext = usuarioViewModel;
        usuarioViewModel.ConsultarCommand.Execute(null);
    }
}
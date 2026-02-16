using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages;

public partial class SedePage : ContentPage
{
	public SedePage(SedePageModel sedePageModel)
	{
		BindingContext = sedePageModel;
		InitializeComponent();
	}
}
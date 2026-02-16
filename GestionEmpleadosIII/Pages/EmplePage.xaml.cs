using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages;

public partial class EmplePage : ContentPage
{
	public EmplePage(EmplePageModel emplePageModel)
	{
		BindingContext = emplePageModel;
		InitializeComponent();
	}
}
using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages;

public partial class DepartPage : ContentPage
{
	public DepartPage(DepartPageModel departPageModel)
	{
        BindingContext = departPageModel;
		InitializeComponent();
	}
}
using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages;

public partial class DetalleDepartPage : ContentPage
{
	public DetalleDepartPage(DetalleDepartPageModel detalleDepart)
	{
		BindingContext = detalleDepart;
        InitializeComponent();
	}
}
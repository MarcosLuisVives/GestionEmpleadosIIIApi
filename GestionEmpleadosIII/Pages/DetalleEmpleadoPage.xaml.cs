using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages;

public partial class DetalleEmpleadoPage : ContentPage
{
	public DetalleEmpleadoPage(DetalleEmpleadoPageModel detalleEmpleado)
	{
		BindingContext = detalleEmpleado;
        InitializeComponent();
	}
}
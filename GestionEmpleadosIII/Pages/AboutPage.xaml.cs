using GestionEmpleadosIII.PageModels;

namespace GestionEmpleadosIII.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageModel aboutPageModel)
	{
        BindingContext = aboutPageModel;
		InitializeComponent();
	}
}
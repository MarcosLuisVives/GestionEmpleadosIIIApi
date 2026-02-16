
using GestionEmpleadosIII.PageModels;


namespace GestionEmpleadosIII.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageModel settingsPageModel)
	{
		BindingContext = settingsPageModel;
		InitializeComponent();
	}
}
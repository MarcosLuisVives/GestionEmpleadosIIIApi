using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GestionEmpleadosIII.PageModels;

public partial class SettingsPageModel : ObservableObject
{
    [ObservableProperty]
    private List<AppTheme> _temas = new() { AppTheme.Unspecified, AppTheme.Light, AppTheme.Dark };

    [ObservableProperty]
    private AppTheme _temaSeleccionado;

    public SettingsPageModel()
    {
        _temaSeleccionado = Application.Current.UserAppTheme;
    }
    partial void OnTemaSeleccionadoChanged(AppTheme value)
    {
        Application.Current.UserAppTheme = value;
    }
}

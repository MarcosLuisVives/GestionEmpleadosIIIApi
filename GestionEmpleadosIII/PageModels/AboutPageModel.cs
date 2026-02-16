using CommunityToolkit.Mvvm.ComponentModel;

namespace GestionEmpleadosIII.PageModels;
public partial class AboutPageModel:ObservableObject
{
    [ObservableProperty]
    private string _title = "Pagina de informacion";
}

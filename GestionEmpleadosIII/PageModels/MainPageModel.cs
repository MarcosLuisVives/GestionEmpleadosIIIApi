using CommunityToolkit.Mvvm.ComponentModel;

namespace GestionEmpleadosIII.PageModels;
public partial class MainPageModel:ObservableObject
{
    [ObservableProperty]
    private string _title = "Pagina Principal";
}

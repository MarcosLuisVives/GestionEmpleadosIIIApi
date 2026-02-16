using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosIII.Models;
using GestionEmpleadosIII.Services;

namespace GestionEmpleadosIII.PageModels;
public partial class EmplePageModel:ObservableObject
{

    private readonly DeparService _deparService;
    private readonly EmpleService _empleService;
    [ObservableProperty]
    private List<Empleado> empleados;
 

    public EmplePageModel(EmpleService empleService , DeparService deparService)
    {
        _empleService = empleService;
        _deparService = deparService;
        LoadEmpleados();
    }

    [RelayCommand]
    public async Task LoadEmpleados()
    {
        
        var deps = await _deparService.GetAllAsync();

        
        var empleados = await _empleService.GetAllAsync();
        foreach (var empleado in empleados)
        {
            empleado.Departamento=deps.FirstOrDefault(d => d.Id == empleado.DepartamentoId);
        }
        Empleados = empleados;
    }
    [ObservableProperty]
    private Empleado empleadoSeleccionado;

    partial void OnEmpleadoSeleccionadoChanged(Empleado value)
    {
        if (value != null)
        {
            IrADetalles(value);
        }
    }

    private async Task IrADetalles(Empleado empleado)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "EmpleadoDetalle", empleado }
        };

        await Shell.Current.GoToAsync("Empleado", navigationParameter);

        EmpleadoSeleccionado = null;
    }

    [RelayCommand]
    private async Task IrACrear()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "EmpleadoDetalle", new Empleado() }
        };

        // Usamos "Empleado" que es el nombre registrado en AppShell.RegisterRoutes
        await Shell.Current.GoToAsync("Empleado", navigationParameter);
    }
}

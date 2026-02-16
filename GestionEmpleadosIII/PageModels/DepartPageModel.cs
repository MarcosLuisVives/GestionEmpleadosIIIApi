using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosIII.Models;
using GestionEmpleadosIII.Services;

public partial class DepartPageModel : ObservableObject
{
    private readonly DeparService _deparService;
    private readonly EmpleService _empleService;
    private readonly SedeService _sedeService;

    [ObservableProperty]
    private List<Departamento> departamentos;

    [ObservableProperty]
    private Departamento departamentoSeleccionado;

    public DepartPageModel(
        DeparService deparService,
        EmpleService empleService,
        SedeService sedeService)
    {
        _deparService = deparService;
        _empleService = empleService;
        _sedeService = sedeService;

       
        LoadDepartamentos();
    }

    [RelayCommand]
    public async Task LoadDepartamentos()
    {
        // Cargar departamentos
        var deps = await _deparService.GetAllAsync();

        // Cargar empleados
        var empleados = await _empleService.GetAllAsync();

        //Cargar sedes
        var sedes = await _sedeService.GetAllAsync();

        //Asignar empleados y sede a cada departamento
        foreach (var dep in deps)
        {
            dep.Empleados = empleados
                .Where(e => e.DepartamentoId == dep.Id)
                .ToList();

            dep.Sede = sedes
                .FirstOrDefault(s => s.Id == dep.SedeId);
        }

        Departamentos = deps;
    }

    partial void OnDepartamentoSeleccionadoChanged(Departamento value)
    {
        if (value != null)
            IrADetalles(value);
    }

    private async Task IrADetalles(Departamento departamento)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "DepartamentoDetalle", departamento }
        };

        await Shell.Current.GoToAsync("Departamento", navigationParameter);

        DepartamentoSeleccionado = null;
    }

    [RelayCommand]
    private async Task IrACrear()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "DepartamentoDetalle", new Departamento() }
        };

        await Shell.Current.GoToAsync("Departamento", navigationParameter);
    }
}
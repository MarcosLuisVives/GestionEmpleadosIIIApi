using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosIII.Models;
using GestionEmpleadosIII.Services;

namespace GestionEmpleadosIII.PageModels;

[QueryProperty(nameof(DepartamentoDetalle), "DepartamentoDetalle")]
public partial class DetalleDepartPageModel:ObservableObject
{
    private readonly DeparService _deparService;
    private readonly SedeService _sedeService;
    public string TituloPagina => DepartamentoDetalle?.Id == 0 ? "Nuevo Departamento" : "Editar Departamento";

    public bool EsEdicion => DepartamentoDetalle?.Id != 0;

    public bool EsNuevo => DepartamentoDetalle?.Id == 0;

    [ObservableProperty]
    private Departamento departamentoDetalle;

    public DetalleDepartPageModel(DeparService deparService)
    {
        _deparService = deparService;
    }
    partial void OnDepartamentoDetalleChanged(Departamento value)
    {
        OnPropertyChanged(nameof(EsEdicion));
        OnPropertyChanged(nameof(EsNuevo));
    }

    [RelayCommand]
    private async Task Eliminar()
    {
        if (DepartamentoDetalle == null) return;

        await _deparService.DeleteAsync(DepartamentoDetalle );

        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (EsNuevo)
            await _deparService.CreateAsync(DepartamentoDetalle);
        else
            await _deparService.UpdateAsync(DepartamentoDetalle);

        await Shell.Current.GoToAsync("..");
    }
}

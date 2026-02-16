using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosIII.Models;
using GestionEmpleadosIII.Services;
using System.Collections.ObjectModel;

namespace GestionEmpleadosIII.PageModels;

public partial class SedePageModel : ObservableObject
{
    private readonly SedeService _sedeService;

    [ObservableProperty]
    private ObservableCollection<Sede> sedes;

    [ObservableProperty]
    private Sede sedeSeleccionada;

    [ObservableProperty]
    private Sede sedeForm = new();

    public bool EsEdicion => SedeForm?.Id != 0;

    public SedePageModel(SedeService sedeService)
    {
        _sedeService = sedeService;
        LoadSedes();
    }

    [RelayCommand]
    public async Task LoadSedes()
    {
        var lista = await _sedeService.GetAllAsync();
        Sedes = new ObservableCollection<Sede>(lista);
    }

    // Al seleccionar una sede de la lista, la cargamos en el formulario
    partial void OnSedeSeleccionadaChanged(Sede value)
    {
        if (value != null)
        {
            // Creamos una copia para no editar directamente en la lista
            SedeForm = new Sede { Id = value.Id, Nombre = value.Nombre };
        }
        else
        {
            SedeForm = new Sede();
        }
        OnPropertyChanged(nameof(EsEdicion));
    }

    [RelayCommand]
    private void LimpiarFormulario()
    {
        SedeSeleccionada = null;
        SedeForm = new Sede();
        OnPropertyChanged(nameof(EsEdicion));
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(SedeForm.Nombre)) return;

        if (!EsEdicion)
            await _sedeService.CreateAsync(SedeForm);
        else
            await _sedeService.UpdateAsync(SedeForm);

        await LoadSedes();
        LimpiarFormulario();
    }

    [RelayCommand]
    private async Task Eliminar()
    {
        if (EsEdicion)
        {
            await _sedeService.DeleteAsync(SedeForm);
            await LoadSedes();
            LimpiarFormulario();
        }
    }
}
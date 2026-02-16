using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpleadosIII.Models;
using GestionEmpleadosIII.Services;

namespace GestionEmpleadosIII.PageModels;
// El primer parámetro es la propiedad del VM (Empleado)
// El segundo es el nombre que se usa en el diccionario ("EmpleadoDetalle")
[QueryProperty(nameof(EmpleadoDetalle), "EmpleadoDetalle")]
public partial class DetalleEmpleadoPageModel : ObservableObject
{
    private readonly EmpleService _empleService;
    public string TituloPagina => EmpleadoDetalle?.Id == 0 ? "Nuevo Empleado" : "Editar Empleado";

    // Esta propiedad indica si estamos editando (ID > 0)
    public bool EsEdicion => EmpleadoDetalle?.Id != 0;

    // Esta indica si estamos creando (ID == 0)
    public bool EsNuevo => EmpleadoDetalle?.Id == 0;

    [ObservableProperty]
    private Empleado empleadoDetalle;

    public DetalleEmpleadoPageModel(EmpleService empleService)
    {
        _empleService = empleService;
    }
    // Cuando se recibe el empleado, notificamos a la UI que estas propiedades cambiaron
    partial void OnEmpleadoDetalleChanged(Empleado value)
    {
        OnPropertyChanged(nameof(EsEdicion));
        OnPropertyChanged(nameof(EsNuevo));
    }

    [RelayCommand]
    private async Task Eliminar()
    {
        if (EmpleadoDetalle == null) return;

        
        await _empleService.DeleteAsync(EmpleadoDetalle);

        // 3. Volver a la lista
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (EmpleadoDetalle == null) return;
        if(EmpleadoDetalle.Departamento == null)
        {
            EmpleadoDetalle.Departamento = new Departamento();
        }
        if (EsNuevo)
        {
            
            await _empleService.CreateAsync(EmpleadoDetalle);
        }
        else
            await _empleService.UpdateAsync(EmpleadoDetalle);

        await Shell.Current.GoToAsync("..");
    }



}

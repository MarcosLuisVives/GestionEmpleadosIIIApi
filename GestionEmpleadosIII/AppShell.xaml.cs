using GestionEmpleadosIII.Pages;
namespace GestionEmpleadosIII;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
            RegisterRoutes();
    }
    public static void RegisterRoutes()
    {
        Routing.RegisterRoute("Empleado", typeof(DetalleEmpleadoPage));
        Routing.RegisterRoute("Departamento", typeof(DetalleDepartPage));
    }
}

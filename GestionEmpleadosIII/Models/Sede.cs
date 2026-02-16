namespace GestionEmpleadosIII.Models;
public class Sede
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Departamento> Departamentos { get; set; } = [];
}

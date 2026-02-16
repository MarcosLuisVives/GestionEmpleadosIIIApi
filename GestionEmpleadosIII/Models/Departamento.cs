

namespace GestionEmpleadosIII.Models;
public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public float Ganancias { get; set; }
    public int SedeId { get; set; }
    public Sede Sede { get; set; }
    public List<Empleado> Empleados { get; set; } = [];

}

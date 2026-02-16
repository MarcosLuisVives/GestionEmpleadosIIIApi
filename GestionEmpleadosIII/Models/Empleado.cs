using System.Text.Json.Serialization;

namespace GestionEmpleadosIII.Models;
public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public string Genero { get; set; } 
    public int Edad { get; set; }
    public string ImagenUri { get; set; }

    //Para evitar problemas con la API, se asigna una imagen por defecto a cada empleado al crearlo
    public string ImageUri { get; set; } = "https://www.thispersondoesnotexist.com/";
    public int DepartamentoId { get; set; } 
    public Departamento Departamento { get; set; }

}

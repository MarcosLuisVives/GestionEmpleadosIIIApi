using GestionEmpleadosIII.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace GestionEmpleadosIII.Services;
public class EmpleService:IRestService<Empleado>
{
    HttpClient _client = new HttpClient();
    JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
    Uri baseUri = new(string.Format("http://localhost:8080/"));


    public async Task<List<Empleado>> GetAllAsync()
    {
        try
        {
            var root = await _client.GetFromJsonAsync<List<Empleado>>(baseUri + "empleados/", _serializerOptions);

            //var root = new List<Empleado>();

            //try
            //{
            //    HttpResponseMessage response = await _client.GetAsync("http://localhost:8080/empleados/");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        string content = await response.Content.ReadAsStringAsync();
            //        root = JsonSerializer.Deserialize<List<Empleado>>(content, _serializerOptions);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //}

            return root;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", "No se pudieron cargar los datos: " + ex.Message, "Aceptar");
            throw new Exception("Error al obtener los empleados");
        }
    }


    public async Task<Empleado> CreateAsync(Empleado item)
    {
        var root = await _client.PostAsJsonAsync(baseUri + "empleados/", item, _serializerOptions);
        if (root.IsSuccessStatusCode)
        {
            var createdItem = await root.Content.ReadFromJsonAsync<Empleado>(_serializerOptions);
            return createdItem;
        }
        else
        {
            var status = root.StatusCode;
            var message = await root.Content.ReadAsStringAsync();
            Debug.WriteLine($"Error del servidor: {status} - {message}");
            throw new Exception("Error al crear");
        }
    }

    public async Task<Empleado> DeleteAsync(Empleado item)
    {
        var root = await _client.DeleteAsync(baseUri + "empleados/" + item.Id);
        if (root.IsSuccessStatusCode)
        {
            return item;
        }
        else
        {
            throw new Exception("Error al eliminar el empleado");
        }
    }

    public async Task<Empleado> GetByIdAsync(int id)
    {
        var root = await _client.GetFromJsonAsync<Empleado>(baseUri + "empleados/" + id, _serializerOptions);
        if (root == null)
        {
            throw new Exception("Error al obtener el empleado");
        }
        return root;
    }

    public async Task<Empleado> UpdateAsync(Empleado item)
    {
        var root = await _client.PatchAsJsonAsync(baseUri + "empleados/" + item.Id, item, _serializerOptions);
        if (root.IsSuccessStatusCode)
        {
            var updatedItem = await root.Content.ReadFromJsonAsync<Empleado>(_serializerOptions);
            return updatedItem;
        }
        else
        {
            var status = root.StatusCode; 
            var message = await root.Content.ReadAsStringAsync(); 
            Debug.WriteLine($"Error del servidor: {status} - {message}");
            throw new Exception("Error al actualizar");
        }
    }
}

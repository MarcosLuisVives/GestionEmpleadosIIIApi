using GestionEmpleadosIII.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace GestionEmpleadosIII.Services;
public class DeparService:IRestService<Departamento>
{
    HttpClient _client = new HttpClient();
    JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
    Uri baseUri = new(string.Format("http://localhost:8080/"));


    public async Task<List<Departamento>> GetAllAsync()
    {
        try
        {
            var root = await _client.GetFromJsonAsync<List<Departamento>>(baseUri + "departamentos/",_serializerOptions);
            return root;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", "No se pudieron cargar los datos: " + ex.Message, "Aceptar");
            throw new Exception("Error al obtener los departamentos");
        }
    }

    public async Task<Departamento> CreateAsync(Departamento item)
    {
        var root = await _client.PostAsJsonAsync(baseUri + "departamentos/", item, _serializerOptions);
        if (root.IsSuccessStatusCode)
        {
            var createdItem = await root.Content.ReadFromJsonAsync<Departamento>(_serializerOptions);
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

    public async Task<Departamento> DeleteAsync(Departamento item)
    {
        var root = await _client.DeleteAsync(baseUri + "departamentos/" + item.Id);
        if (root.IsSuccessStatusCode)
        {
            return item;
        }
        else
        {
            throw new Exception("Error al eliminar el departamento");
        }
    }

    public async Task<Departamento> GetByIdAsync(int id)
    {
        var root = await _client.GetFromJsonAsync<Departamento>(baseUri + "departamentos/" + id,_serializerOptions);
        if (root == null)
        {
            throw new Exception("Error al obtener el departamento");
        }
        return root;
    }

    public async Task<Departamento> UpdateAsync(Departamento item)
    {
        var root = await _client.PatchAsJsonAsync(baseUri + "departamentos/" + item.Id, item, _serializerOptions);
        if (root.IsSuccessStatusCode)
        {
            var updatedItem = await root.Content.ReadFromJsonAsync<Departamento>(_serializerOptions);
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

using GestionEmpleadosIII.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace GestionEmpleadosIII.Services;
public class SedeService:IRestService<Sede>
{
    HttpClient _client = new HttpClient();
    JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
    Uri baseUri = new(string.Format("http://localhost:8080/"));


    public async Task<List<Sede>> GetAllAsync()
    {
        try
        {
            var root = await _client.GetFromJsonAsync<List<Sede>>(baseUri + "sedes/", _serializerOptions);
            return root;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", "No se pudieron cargar los datos: " + ex.Message, "Aceptar");
            throw new Exception("Error al obtener los sedes");
        }
    }

    public async Task<Sede> CreateAsync(Sede item)
    {
        var root = await _client.PostAsJsonAsync(baseUri + "sedes/", item, _serializerOptions);
        if (root.IsSuccessStatusCode)
        {
            var createdItem = await root.Content.ReadFromJsonAsync<Sede>(_serializerOptions);
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

    public async Task<Sede> DeleteAsync(Sede item)
    {
        var root = await _client.DeleteAsync(baseUri + "sedes/" + item.Id);
        if (root.IsSuccessStatusCode)
        {
            return item;
        }
        else
        {
            throw new Exception("Error al eliminar el sedes");
        }
    }

    public async Task<Sede> GetByIdAsync(int id)
    {
        var root = await _client.GetFromJsonAsync<Sede>(baseUri + "sedes/" + id,_serializerOptions);
        if (root == null)
        {
            throw new Exception("Error al obtener el sede");
        }
        return root;
    }

    public async Task<Sede> UpdateAsync(Sede item)
    {
        var root = await _client.PatchAsJsonAsync(baseUri + "sedes/" + item.Id, item, _serializerOptions);
        if (root.IsSuccessStatusCode)
        {
            var updatedItem = await root.Content.ReadFromJsonAsync<Sede>(_serializerOptions);
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

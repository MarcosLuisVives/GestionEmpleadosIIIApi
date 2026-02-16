namespace GestionEmpleadosIII.Services;
public interface IRestService<T>
{
    public Task<List<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task<T> CreateAsync(T item);
    public Task<T> UpdateAsync(T item);
    public Task<T> DeleteAsync(T item);

}

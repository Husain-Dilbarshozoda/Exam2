namespace Infastructure;

public interface IGenericService<T>
{
    Task<Response<bool>> Create(T data);
    Task<Response<List<T>>> GetAll();
    Task<Response<T>> GetById(int id);
    Task<Response<bool>> Update(T data);
    Task<Response<bool>> Delete(int id);
}
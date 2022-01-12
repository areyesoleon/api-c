namespace MasterAPI.tools
{
    public interface ApiInterface<T>
    {
        Task Post(T data);
        Task Put(T data);
        Task Delete(string id);
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
    }
}
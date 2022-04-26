using System.Threading.Tasks;

namespace StoreWeb.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, int Id);
        Task<bool> CreateAsync(string url, T objToCreate);
        Task<T> CreateAsyncAndReturnObjToCreate(string url, T objToCreate);
        Task<bool> UpdateAsync(string url, T objToUpdate);

    }
}




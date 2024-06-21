
namespace DemoOnionArchitecture.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetList();
    }
}
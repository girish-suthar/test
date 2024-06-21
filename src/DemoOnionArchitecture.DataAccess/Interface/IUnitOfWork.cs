
namespace DemoOnionArchitecture.DataAccess.Interface
{
    public interface IUnitOfWork
    {
        IVillaRepository Villas { get; }

        Task SaveDbChangesAsync();
    }
}
using DemoOnionArchitecture.Domain.Entity;

namespace DemoOnionArchitecture.Application.Abstract
{
    public interface IVillaService
    {
        Task<List<Villa>> GetList();
    }
}
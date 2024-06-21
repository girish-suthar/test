using DemoOnionArchitecture.DataAccess.Context;
using DemoOnionArchitecture.DataAccess.Interface;
using DemoOnionArchitecture.Domain.Entity;

namespace DemoOnionArchitecture.DataAccess.Repositories
{
    public class VillaRepository(ApplicationdbContext context) : Repository<Villa>(context), IVillaRepository
    {

    }
}

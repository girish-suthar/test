using DemoOnionArchitecture.DataAccess.Context;
using DemoOnionArchitecture.DataAccess.Interface;
using DemoOnionArchitecture.DataAccess.Repositories;

namespace DemoOnionArchitecture.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationdbContext _context;

        public UnitOfWork(ApplicationdbContext context)
        {
            _context = context;
            Villas = new VillaRepository(_context);
        }

        public IVillaRepository Villas { get; private set; }
        public async Task SaveDbChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

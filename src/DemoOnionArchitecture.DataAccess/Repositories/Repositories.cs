using DemoOnionArchitecture.DataAccess.Context;
using DemoOnionArchitecture.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOnionArchitecture.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationdbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationdbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }       

        public async Task<List<T>> GetList()
        {
            return await _dbSet.ToListAsync();
        }

    }
}

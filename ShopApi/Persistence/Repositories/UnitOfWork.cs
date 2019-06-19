using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Domain.Repositories;
using ShopApi.Persistence.Contexts;

namespace ShopApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopApiContext _context;

        public UnitOfWork(ShopApiContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

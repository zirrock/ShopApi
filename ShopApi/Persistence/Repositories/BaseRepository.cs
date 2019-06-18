using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Persistence.Contexts;

namespace ShopApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ShopApiContext _context;

        public BaseRepository(ShopApiContext context)
        {
            _context = context;
        }
    }
}

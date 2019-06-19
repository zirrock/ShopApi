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
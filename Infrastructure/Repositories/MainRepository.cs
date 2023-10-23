using Domain;
using Domain.SharedContext;

namespace Infrastructure.Repositories
{
    public class MainRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AppDBContext _context;

        public MainRepository(AppDBContext contex)
        {
            _context = contex;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

    }
}

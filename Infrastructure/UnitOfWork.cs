
using Domain;
using SimpleObjects.ContentContext;

namespace Infrastructure
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
           return await _context.SaveChangesAsync();
        }

    }
}

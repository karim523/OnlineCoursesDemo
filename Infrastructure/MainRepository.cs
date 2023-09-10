using Domain;
using Domain.SharedContext;
using Infrastructure;
using SimpleObjects.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MainRepository<T>:IRepository<T> where T : IEntity
    {
        private readonly AppDBContext _context;

        public MainRepository(AppDBContext contex)
        {
            this._context = contex;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}

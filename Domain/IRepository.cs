using Domain.SharedContext;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<T> where T : class,IEntity
    {
        Task Create(T myItem);    
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : IEntity
    {
        Task Create(T entity);
        Task Remove(Guid id);
        Task Update(T entity);
        Task<T> Get(Guid id);
        Task<IReadOnlyCollection<T>> GetAll();
    }
}

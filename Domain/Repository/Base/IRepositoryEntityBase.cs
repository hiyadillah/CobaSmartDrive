using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Base
{
    public interface IRepositoryEntityBase<TEntity,TRequest>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity>GetById(int id);
        Task<TEntity>Create(TRequest entity);
        Task<TEntity>Update(int id,TRequest entity);
        Task Delete(int id);
        Task<int> SaveChangesAsync();
    }
}

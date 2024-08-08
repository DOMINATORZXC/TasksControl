using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<List<T>> Select();
        Task<bool> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
    }
}

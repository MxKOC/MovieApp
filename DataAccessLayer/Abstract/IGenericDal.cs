using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {

            Task<T> GetByIdAsync(string id);
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> AddAsync(T entity);
            Task UpdateAsync(T entity);
            Task DeleteAsync(string id);
            public Task<IEnumerable<T>> GetByReaderIdAsync(string readerId);
            public Task<IEnumerable<T>> GetByWriterIdAsync(string writerId);
        }
}

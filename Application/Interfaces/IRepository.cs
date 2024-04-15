using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Получить по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TEntity> Get();
        public TEntity GetByID(Guid id);
        public TEntity Add(TEntity person);
        public TEntity Update(TEntity person);
        public void Delete(TEntity person);
    }
}

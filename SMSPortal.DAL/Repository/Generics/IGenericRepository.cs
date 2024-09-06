using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.Repository.GenericRepositories
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity? GetById(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);


        void Delete(TEntity Entity);
    }
}

using Microsoft.EntityFrameworkCore;
using SMSPortal.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.Repository.GenericRepositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private protected ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);

        }

        public void Update(TEntity entity)
        {

        }
    }
}

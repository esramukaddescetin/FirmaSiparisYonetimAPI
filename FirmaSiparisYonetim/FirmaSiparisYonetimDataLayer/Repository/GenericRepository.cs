using Microsoft.EntityFrameworkCore.ChangeTracking;
using FirmaSiparisYonetimDataLayer.Context;

namespace FirmaSiparisYonetimDataLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private SiparisYonetimDBContext _dbContext;

        public GenericRepository(SiparisYonetimDBContext context)
        {
            _dbContext = context;
        }

        public T Add(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public IQueryable<T> All()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            T? entity = _dbContext.Set<T>().Find(id);

            if (entity == null)
                return;

            _dbContext.Set<T>().Remove(entity);
        }


        public T? Find(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T? Update(T entity)
        {
            EntityEntry<T> updatedItem = _dbContext.Set<T>().Update(entity);
            return updatedItem.Entity;
        }
    }
}

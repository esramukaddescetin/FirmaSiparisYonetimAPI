using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace FirmaSiparisYonetimDataLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);

        IQueryable<T> All();
        void Delete(T entity);

        void Delete(int id);


        T? Find(int id);

        T? Update(T entity);
    }
}
using FirmaSiparisYonetimDataLayer.Repository;

namespace FirmaSiparisYonetimDataLayer.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
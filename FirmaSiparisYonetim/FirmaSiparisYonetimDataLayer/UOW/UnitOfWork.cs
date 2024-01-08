using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirmaSiparisYonetimDataLayer.Context;
using FirmaSiparisYonetimDataLayer.Repository;

namespace FirmaSiparisYonetimDataLayer.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SiparisYonetimDBContext _context;
        public UnitOfWork()
        {
            _context = new SiparisYonetimDBContext();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public int SaveChanges() => _context.SaveChanges();

        #region Disposable

        public bool Disposed { get; set; }
        public void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static IUnitOfWork Create()
        {
            return new UnitOfWork();
        }

        #endregion

    }
}

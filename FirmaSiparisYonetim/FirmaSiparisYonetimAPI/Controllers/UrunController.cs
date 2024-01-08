using FirmaSiparisYonetimAPI.DTOModels;
using FirmaSiparisYonetimAPI.Requests;
using FirmaSiparisYonetimDataLayer.Tables;
using FirmaSiparisYonetimDataLayer.UOW;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrunController : Controller
    {
        private IUnitOfWork _uow;
        public UrunController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("UrunEkle")]
        public GenelYanit UrunEkle(UrunEkleIstek urunBilgisi)
        {

            var firma = _uow.GetRepository<Firma>().Find(urunBilgisi.FirmaId);
            if (firma == null)
                return new GenelYanit(false, "Firma Bulunamadı!");

            var urun = _uow.GetRepository<Urun>().Add(new Urun
            {
                Adi = urunBilgisi.Adi,
                FirmaId = urunBilgisi.FirmaId,
                Fiyat = urunBilgisi.Fiyat,
                Stok = urunBilgisi.Stok
            });

            _uow.SaveChanges();

            return new GenelYanit(UrunToUrunDTO(urun));
        }

        private static UrunDTO UrunToUrunDTO(Urun urun)
        {
            return new UrunDTO
            {
                Id = urun.Id,
                Stok = urun.Stok,
                Adi = urun.Adi,
                Fiyat = urun.Fiyat
            };
        }
    }
}

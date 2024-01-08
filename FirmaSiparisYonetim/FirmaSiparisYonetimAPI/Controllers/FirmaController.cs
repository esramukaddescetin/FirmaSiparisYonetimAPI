using FirmaSiparisYonetimAPI.DTOModels;
using FirmaSiparisYonetimAPI.Requests;
using FirmaSiparisYonetimDataLayer.Tables;
using FirmaSiparisYonetimDataLayer.UOW;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirmaController : Controller
    {
        private IUnitOfWork _uow;
        public FirmaController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("Firmalar")]
        public List<FirmaDTO> Firmalar()
        {
            return _uow.GetRepository<Firma>().All().Select(f => FirmaDataToObject(f)).ToList();
        }

        [HttpPost("FirmaGuncelle")]
        public GenelYanit FirmaGuncelle(FirmaGuncelleIstek firmaGuncelVeri)
        {

            Firma? firma = _uow.GetRepository<Firma>().Find(firmaGuncelVeri.FirmaId);
            if (firma == null)
                return new GenelYanit(false, $"Firma bulunamadı!");

            firma.Onay = firmaGuncelVeri.Onay;
            firma.SiparisIzinBaslangicSaati = firmaGuncelVeri.SiparisIzinBaslangicSaati;
            firma.SiparisIzinBitisSaati = firmaGuncelVeri.SiparisIzinBitisSaati;

            _uow.SaveChanges();

            return new GenelYanit(FirmaDataToObject(firma));
        }

        [HttpPost("FirmaEkle")]
        public GenelYanit FirmaEkle(FirmaEkleIstek firmaEkleVeri)
        {
            var firma = _uow.GetRepository<Firma>().Add(new Firma
            {
                Adi = firmaEkleVeri.Adi,
                Onay = firmaEkleVeri.Onay,
                SiparisIzinBaslangicSaati = firmaEkleVeri.SiparisBaslangicSaati,
                SiparisIzinBitisSaati = firmaEkleVeri.SiparisBitisSaati
            });

            _uow.SaveChanges();

            return new GenelYanit(FirmaDataToObject(firma));
        }

        private static FirmaDTO FirmaDataToObject(Firma firma)
        {
            return new FirmaDTO
            {
                Adi = firma.Adi,
                Id = firma.Id,
                Onay = firma.Onay,
                SiparisIzinBaslangicSaati = firma.SiparisIzinBaslangicSaati,
                SiparisIzinBitisSaati = firma.SiparisIzinBitisSaati,
                Siparisler = firma.Siparisler?.Select(s => new SiparisDTO
                {
                    Id = s.Id,
                    KisiAdi = s.KisiAdi,
                    SiparisTarihi = s.SiparisTarihi,
                    UrunId = s.UrunId,
                }).ToList(),
                Urunler = firma.Urunler?.Select(u => new UrunDTO
                {
                    Id = u.Id,
                    Adi = u.Adi,
                    Fiyat = u.Fiyat,
                    Stok = u.Stok
                }).ToList()
            };
        }
    }
}

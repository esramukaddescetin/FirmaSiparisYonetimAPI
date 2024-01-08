using FirmaSiparisYonetimAPI.DTOModels;
using FirmaSiparisYonetimAPI.Requests;
using FirmaSiparisYonetimDataLayer.Tables;
using FirmaSiparisYonetimDataLayer.UOW;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiparisController : Controller
    {
        private IUnitOfWork _uow;
        public SiparisController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("SiparisOlustur")]
        public GenelYanit SiparisOlustur(SiparisOlusturIstek siparisVeri)
        {

            Firma? firma = _uow.GetRepository<Firma>().Find(siparisVeri.FirmaId);
            if (firma == null)
                return new GenelYanit(false, "Firma Bulunamadı!");

            if (firma.Onay == false)
                return new GenelYanit(false, "Firma Onaylı Değil!");

            Urun? urun = _uow.GetRepository<Urun>().Find(siparisVeri.UrunId);
            if (urun == null)
                return new GenelYanit(false, "Ürün Bulunamadı!");

            DateTime baslangic = new DateTime(firma.SiparisIzinBaslangicSaati.TimeOfDay.Ticks);
            DateTime bitis = new DateTime(firma.SiparisIzinBitisSaati.TimeOfDay.Ticks);
            DateTime suan = new DateTime(siparisVeri.SiparisSaati.TimeOfDay.Ticks);

            if (suan < baslangic || suan > bitis)
                return new GenelYanit(false, "Firma şuan sipariş almıyor!");


            var siparis = _uow.GetRepository<Siparis>().Add(new Siparis
            {
                KisiAdi = siparisVeri.KisiAdi,
                FirmaId = firma.Id,
                UrunId = urun.Id,
                SiparisTarihi = siparisVeri.SiparisSaati
            });

            _uow.SaveChanges();

            return new GenelYanit(SiparisToSiparisDTO(siparis));
        }

        private static SiparisDTO SiparisToSiparisDTO(Siparis siparis)
        {
            return new SiparisDTO
            {
                Id = siparis.Id,
                KisiAdi = siparis.KisiAdi,
                SiparisTarihi = siparis.SiparisTarihi,
                UrunId = siparis.UrunId,
            };
        }
    }
}

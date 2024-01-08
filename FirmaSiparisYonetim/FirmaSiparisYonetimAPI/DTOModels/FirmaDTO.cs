using static FirmaSiparisYonetimAPI.Controllers.FirmaController;

namespace FirmaSiparisYonetimAPI.DTOModels
{
    public class FirmaDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Onay { get; set; }
        public DateTime SiparisIzinBaslangicSaati { get; set; }
        public DateTime SiparisIzinBitisSaati { get; set; }
        public List<UrunDTO>? Urunler { get; set; }
        public List<SiparisDTO>? Siparisler { get; set; }

        public FirmaDTO()
        {
            Urunler = new List<UrunDTO>();
            Siparisler = new List<SiparisDTO>();
        }
    }

}

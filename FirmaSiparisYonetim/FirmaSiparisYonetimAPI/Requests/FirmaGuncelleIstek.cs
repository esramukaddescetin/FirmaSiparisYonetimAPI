namespace FirmaSiparisYonetimAPI.Requests
{
    public class FirmaGuncelleIstek
    {
        public int FirmaId { get; set; }
        public bool Onay { get; set; }
        public DateTime SiparisIzinBaslangicSaati { get; set; }
        public DateTime SiparisIzinBitisSaati { get; set; }
    }
}

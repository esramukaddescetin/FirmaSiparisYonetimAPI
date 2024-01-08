namespace FirmaSiparisYonetimAPI.Requests
{
    public class FirmaEkleIstek
    {
        public string Adi { get; set; }
        public bool Onay { get; set; }
        public DateTime SiparisBaslangicSaati { get; set; }
        public DateTime SiparisBitisSaati { get; set; }
    }
}

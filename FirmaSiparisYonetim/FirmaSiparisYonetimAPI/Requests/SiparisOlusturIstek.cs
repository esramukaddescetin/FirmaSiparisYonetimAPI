namespace FirmaSiparisYonetimAPI.Requests
{
    public class SiparisOlusturIstek
    {
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public string KisiAdi { get; set; }
        public DateTime SiparisSaati { get; set; }
    }
}

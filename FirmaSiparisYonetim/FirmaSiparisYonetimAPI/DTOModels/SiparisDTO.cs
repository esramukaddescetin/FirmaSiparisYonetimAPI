namespace FirmaSiparisYonetimAPI.DTOModels
{
    public class SiparisDTO
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public string KisiAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }

    }
}

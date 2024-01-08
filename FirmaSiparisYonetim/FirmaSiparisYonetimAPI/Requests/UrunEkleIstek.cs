namespace FirmaSiparisYonetimAPI.Requests
{
    public class UrunEkleIstek
    {
        public int FirmaId { get; set; }
        public string Adi { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }
    }
}

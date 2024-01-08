namespace FirmaSiparisYonetimDataLayer.Tables
{
    public class Firma
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Onay { get; set; }
        public DateTime SiparisIzinBaslangicSaati { get; set; }
        public DateTime SiparisIzinBitisSaati { get; set; }

        public ICollection<Urun> Urunler { get; set; }
        public ICollection<Siparis> Siparisler { get; set; }
    }
}

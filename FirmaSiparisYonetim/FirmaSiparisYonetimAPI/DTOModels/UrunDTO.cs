namespace FirmaSiparisYonetimAPI.DTOModels
{
    public class UrunDTO
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public string Adi { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }
    }

}

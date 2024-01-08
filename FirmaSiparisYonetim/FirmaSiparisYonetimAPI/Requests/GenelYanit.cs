namespace FirmaSiparisYonetimAPI.Requests
{
    public class GenelYanit
    {
        public object Data { get; set; }
        public bool Basarili { get; set; }
        public string Mesaj { get; set; }

        public GenelYanit(bool basarili)
        {
            Basarili = basarili;
        }

        public GenelYanit(bool basarili, string mesaj)
        {
            Basarili = basarili;
            Mesaj = mesaj;
        }

        public GenelYanit(object data)
        {
            Data = data;
            Basarili = true;
        }
    }
}

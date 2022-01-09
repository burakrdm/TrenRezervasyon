using System.Collections.Generic;

namespace TrenRezervasyon.Model
{

    public class Vagonlar
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
    }

    public class Tren
    {
        public string Ad { get; set; }
        public List<Vagonlar> Vagonlar { get; set; }
    }

    public class TrenModel
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrenRezervasyon.Model
{
    public class YerlesimAyrinti
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }

    public class YerlesimModel
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}

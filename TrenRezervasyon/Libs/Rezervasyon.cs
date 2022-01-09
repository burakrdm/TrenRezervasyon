using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenRezervasyon.Model;

namespace TrenRezervasyon.Libs
{
    public class Rezervasyon
    {
        public YerlesimModel RezervasyonYap(TrenModel trenModel) 
        {
            var yerlesimModel = new YerlesimModel();
            var yerlesimAyrinti = new List<YerlesimAyrinti>();
                      
            foreach (var item in trenModel.Tren.Vagonlar)
            {
                // VAGON 1 = 100 KOLTUK VAR 70 REZERVE HAKKI VAR
                int maxRezerveKapasitesi = (item.Kapasite * 70)/ 100;

                if (maxRezerveKapasitesi > item.DoluKoltukAdet) 
                {
                    //8 kişi rez etmek istiyorum. Elimde 5 koltuk var bu vagnda
                    //5                      70                    65
                    int rezerveyeUygunAdet = maxRezerveKapasitesi - item.DoluKoltukAdet;

                    //8                     5
                    if (rezerveyeUygunAdet >= trenModel.RezervasyonYapilacakKisiSayisi)
                    {
                        yerlesimAyrinti.Add(new YerlesimAyrinti
                        {
                            VagonAdi = item.Ad,
                            KisiSayisi = trenModel.RezervasyonYapilacakKisiSayisi
                        });

                        trenModel.RezervasyonYapilacakKisiSayisi = 0;
                        break;
                    }
                    else
                    {

                        if (!trenModel.KisilerFarkliVagonlaraYerlestirilebilir) break;

                        yerlesimAyrinti.Add(new YerlesimAyrinti
                        {
                            VagonAdi = item.Ad,
                            KisiSayisi = rezerveyeUygunAdet
                        });

                        trenModel.RezervasyonYapilacakKisiSayisi = trenModel.RezervasyonYapilacakKisiSayisi - rezerveyeUygunAdet;
                    }
                }
            }

            if (trenModel.RezervasyonYapilacakKisiSayisi != 0)
            {
                yerlesimAyrinti.Clear();
                yerlesimModel.RezervasyonYapilabilir = false;
            }
            else
            {
                yerlesimModel.RezervasyonYapilabilir = true;
            }

            yerlesimModel.YerlesimAyrinti = yerlesimAyrinti;

            return yerlesimModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelalKumbara
{
    public class EklenecekTutar
    {
        public Para SeciliPara { get; set; }
        public int Adet { get; set; }
        public double ToplamTutar { get; set; }

        public void Hesapla()
        {
            ToplamTutar = 0;
            ToplamTutar += SeciliPara.Degeri;

            ToplamTutar = ToplamTutar * Adet;
        }

        public override string ToString()
        {
            if (SeciliPara.Degeri < 1)
                return string.Format("{0}, {1} Adet, Toplam : {2} Kuruş", SeciliPara.ParaAdi, Adet, ToplamTutar);
            else
            {

                //exMalzemeler = exMalzemeler.Trim(',');

                return string.Format("{0}, {1} Adet, Toplam : {2} TL", SeciliPara.ParaAdi, Adet, ToplamTutar);

            }
        }
    }
}

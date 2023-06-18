using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelalKumbara
{
    public class Para
    {
        public string ParaAdi { get; set; }
        public double Degeri { get; set; }
        public double Hacmi { get; set; }
        public override string ToString() => ParaAdi;
    }
}

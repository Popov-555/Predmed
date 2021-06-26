using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimurEXZ.Model
{
   public class Abiturent
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Spec { get; set; }
        public double Ball { get; set; }
        public DateTime Datepost { get; set; }
        public string Date
        {
            get
            {
                return Datepost.ToShortDateString();
            }
        }
    }
}

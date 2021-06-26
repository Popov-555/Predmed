using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimurEXZ.Model
{
    public class LocalDataProvider : IDataProvider
    {
        public IEnumerable<AbitSpec> GetAbitSpecs()
        {
            return new AbitSpec[]
            {
                new AbitSpec {Title = "Программист"},
                new AbitSpec {Title = "Инженер"},
                new AbitSpec {Title = "Дизайнер"}
            };
        }

        public IEnumerable<Abiturent> GetAbiturents()
        {
            return new Abiturent[]
            {
               new Abiturent { Name = "Тимур Игимбаев", Age = 17, Spec = "Программист", Ball = 4.09, Datepost = new DateTime (2019,05,19)},
                new Abiturent { Name = "Антон Усепов", Age = 18, Spec = "Дизайнер", Ball = 3.55, Datepost = new DateTime (2020,05,19)},
                 new Abiturent { Name = "Владимир Соловьёв", Age = 17, Spec = "Инженер", Ball = 4.59, Datepost = new DateTime (2020,08,25)},
            };
        }
    }
}

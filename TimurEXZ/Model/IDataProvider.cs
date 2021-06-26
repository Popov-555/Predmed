using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimurEXZ.Model
{
   public interface IDataProvider
    {
        IEnumerable<Abiturent> GetAbiturents();
        IEnumerable<AbitSpec> GetAbitSpecs();
    }
}

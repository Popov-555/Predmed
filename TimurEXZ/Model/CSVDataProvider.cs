using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimurEXZ.Model
{
    public class CSVDataProvider : IDataProvider
    {
        private List<Abiturent> AbiturentList = new List<Abiturent>();
        public CSVDataProvider(string FileName)
        {

            using (TextFieldParser parser = new TextFieldParser(FileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    AbiturentList.Add(
                        new Abiturent
                        {
                            Name = fields[0],
                            Age = int.Parse(fields[1]),
                            Spec = fields[2],
                            Ball = double.Parse(fields[3]),
                            Datepost = DateTime.Parse(fields[4])
                        }
                        );
                }
            }
        }

        public IEnumerable<AbitSpec> GetAbitSpecs()
        {
            return new AbitSpec[]
            {
                new AbitSpec {Title = "Программист"},
                new AbitSpec {Title = "Дизайнер"},
                new AbitSpec {Title = "Инженер"}
            };
        }

        public IEnumerable<Abiturent> GetAbiturents()
        {
            return AbiturentList;
        }
    }
}
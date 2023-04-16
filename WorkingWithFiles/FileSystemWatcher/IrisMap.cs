using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace FileSystemWatchers
{
    public class IrisMap : ClassMap<ProcessedIris>
    {
        public IrisMap()
        {
            Map(s=>s.petalLength).Name("petal_length");
            Map(s=>s.petalWidth).Name("petal_width");
            Map(s=>s.sepalLength).Name("sepal_length");
            Map(s=>s.sepalWidth).Name("sepal_width");
            Map(s=>s.variety).Name("variety");

        }   
    }
}
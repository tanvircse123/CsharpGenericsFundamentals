using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace FileSystemWatchers
{
    public class CsvFileProcessor
    {
        private string _inputFilePath;
        private string _outputFilepath;

        public CsvFileProcessor(string inputFilePath,string outputFilepath)
        {
            _inputFilePath = inputFilePath;
            _outputFilepath = outputFilepath;
        }

        public void Process1(){
                // reading a csv file with csv helper
                using StreamReader inputReader = File.OpenText(_inputFilePath);
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Comment = '@',
                    AllowComments = true,
                    TrimOptions = TrimOptions.Trim,
                    IgnoreBlankLines = true,
                    Delimiter = "," // you can add custom delimiter
                };
                using CsvReader csvReader = new CsvReader(inputReader,csvConfiguration);
                csvReader.Context.RegisterClassMap<IrisMap>();
                IEnumerable<ProcessedIris> records = csvReader.GetRecords<ProcessedIris>();
                // foreach(ProcessedIris record in records){
                //     Console.WriteLine(record.sepalLength);
                //     Console.WriteLine(record.sepalWidth);
                //     Console.WriteLine(record.petalLength);
                //     Console.WriteLine(record.petalWidth);
                //     Console.WriteLine(record.variety);
                // }


                // we get the record now we ned to write to another file
                using StreamWriter outputWriter = File.CreateText(_outputFilepath);
                using var csvWriter = new CsvWriter(outputWriter,CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(records);
        }
    }
}
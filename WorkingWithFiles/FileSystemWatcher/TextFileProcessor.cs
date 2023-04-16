using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text; /// encoding comes in the System.Text

namespace FileSystemWatchers
{
    public class TextFileProcessor
    {
        private string _inputFilePath;
        private string _outputFilePath;

        public TextFileProcessor(string inputFilePath,string outputFilePath)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
        }

        public void Process1(){
            var originalText = File.ReadAllText(_inputFilePath,Encoding.UTF8);
            var processedText = originalText.ToUpperInvariant();
            File.WriteAllText(_outputFilePath,processedText);
            
        }

        public void Process2(){
            var lines = File.ReadAllLines(_inputFilePath,Encoding.UTF8);
            lines[0] = lines[0].ToUpperInvariant();
            try{
                File.WriteAllLines(_outputFilePath,lines);
            }catch{
                throw;
            }
        }


        public void Process3(){
            // using Stream to read file
            using var inputFileStream    = new FileStream(_inputFilePath,FileMode.Open);
            using var inputStreamReader  = new StreamReader(inputFileStream);
            using var outputFileStream   = new FileStream(_outputFilePath,FileMode.CreateNew);
            using var outputstreamWriter = new StreamWriter(outputFileStream);
            while(!inputStreamReader.EndOfStream){
                // get a single line at a time
                var inputLine = inputStreamReader.ReadLine();
                var processedLine = inputLine.ToUpperInvariant();
                outputstreamWriter.WriteLine(processedLine);
            }
            
            
        }
        public void Process3Shorter(){
            using StreamReader inputStreamReader = File.OpenText(_inputFilePath);
            using StreamWriter outputStrreamWriter = new StreamWriter(_outputFilePath);
            while(!inputStreamReader.EndOfStream){
                var inputLine = inputStreamReader.ReadLine();
                var processedLine = inputLine.ToUpperInvariant();
                bool isLastLine = inputStreamReader.EndOfStream;
                if(isLastLine){
                    outputStrreamWriter.Write(processedLine);
                }else{
                    outputStrreamWriter.WriteLine(processedLine);
                }
            } 

    
        }
        public void Process2Line(){
            using StreamReader inputStreamReader = File.OpenText(_inputFilePath);
            using StreamWriter outputStrreamWriter = new StreamWriter(_outputFilePath);
            var currentLine = 1;
            while(!inputStreamReader.EndOfStream){
                string inputLine = inputStreamReader.ReadLine();
                if(currentLine == 2){
                    inputLine = inputLine.ToUpperInvariant();
                }
                bool isLastLine = inputStreamReader.EndOfStream;
                if(isLastLine){
                    outputStrreamWriter.Write(inputLine);
                }else{
                    outputStrreamWriter.WriteLine(inputLine);
                }
                currentLine++;
            }
        }





    }
}
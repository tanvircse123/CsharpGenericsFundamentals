using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemWatchers
{
    public class BinaryFileProcessor
    {
        private string _inputFilePath;
        private string _outputFilePath;

        public BinaryFileProcessor(string inputFilePath,string outputFilePath)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
        }

        public void Process1(){
            using FileStream inputFileStream = File.Open(_inputFilePath, FileMode.Open,FileAccess.Read);
            using FileStream outputFileStream = File.OpenWrite(_outputFilePath);
            while(inputFileStream.Position < inputFileStream.Length){
                byte databyte = (byte)inputFileStream.ReadByte();
                outputFileStream.WriteByte(databyte);
            }
        }
    }
}
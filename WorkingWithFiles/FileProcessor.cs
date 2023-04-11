using System.IO;
namespace WorkingWithFiles
{
    public class FileProcessor
    {
	   public string _InputFilePath {get;set;}
       
       public FileProcessor (string filePath) 
       {
          _InputFilePath = filePath;
       }


       public void Process(){

        Console.WriteLine($"Begin process of {_InputFilePath}");
        // check if the file exists
        if (!File.Exists(_InputFilePath)){
            Console.WriteLine($"ERROR: file {_InputFilePath} does not exists");
            return;
        }

        // return the full name of the parent directory
        var rootDirectoryPath = new DirectoryInfo(_InputFilePath).Parent.FullName;
        Console.WriteLine($"Root Data Path is {rootDirectoryPath}");
        Console.ReadLine();
       }



       
        
    }
}
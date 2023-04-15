using System.IO;
namespace WorkingWithFiles
{
    public class FileProcessor
    {
	   public string _InputFilePath {get;set;}
       public const string BackupDirectoryName = "backup";
       public const string InProgressDirectoryName = "processing";
       public const string CompletedDirectoryName = "complete";
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
        // go one level up
        var rootofrootpath = new DirectoryInfo(_InputFilePath).Parent.Parent.FullName;

        // vreate a backup directory
        // with path
        var backupDirectoryPath = Path.Combine(rootofrootpath,BackupDirectoryName);
        if(!Directory.Exists(backupDirectoryPath)){
            Console.WriteLine($"Creating directory {backupDirectoryPath} ");
            Directory.CreateDirectory(backupDirectoryPath);
        }else{
            Console.WriteLine("Already a Directory exists");
        }

        // copy file to a backup directory
        // from the path we extract the file name with extension
        string inputFileName = Path.GetFileName(_InputFilePath);
        string backupFilePath = Path.Combine(backupDirectoryPath,inputFileName);
        Console.WriteLine($"Copying {_InputFilePath} to {backupFilePath}");
        //File.Copy(_inputPath,OutputPath,isOverrite)
        // if you want overwritten then third parameter will be true

        File.Copy(_InputFilePath,backupFilePath,true);
        
        

        // creating the inprogress directory
        var InprogressDirectorypath = Path.Combine(rootofrootpath,InProgressDirectoryName);
        // check if the directory already exists
        if(!Directory.Exists(InprogressDirectorypath)){
            Directory.CreateDirectory(InprogressDirectorypath);
        }else{
            Console.WriteLine("Already a Directory Exists");
        }

        // create the in progress file path

        var inputFilename = Path.GetFileName(_InputFilePath);
        var inprogressFilePath = Path.Combine(InprogressDirectorypath,inputFilename);
        // check if the inprogress File Already exists or not
        if(File.Exists(inprogressFilePath)){
            Console.WriteLine("Error: File with the same name already exists");
            return;
        }

        Console.WriteLine($"Moving {_InputFilePath} to {inprogressFilePath}");
        File.Move(_InputFilePath,inprogressFilePath,true);
        Console.WriteLine("File Moved");
        


        // now process the file based on their extension
        // get the extension first
        var extension = Path.GetExtension(_InputFilePath);
        switch(extension)
        {
            case ".txt":
                Console.Write("A text File Detected");
                ProcessTextFile(inprogressFilePath);
                break;
            default:
                Console.WriteLine($"{extension} is not Supported");
                break;
        }
        // after processing the file we send the file to the completed folder
        //send the file to the completed folder
        var completedDirectorypath = Path.Combine(rootofrootpath,CompletedDirectoryName);
        if(!Directory.Exists(completedDirectorypath)){
            Directory.CreateDirectory(completedDirectorypath);
        }
        Console.WriteLine($"Moving {inprogressFilePath} to {completedDirectorypath}");
            
            // 1) get the file name without the extension
            // 2) addded a guid
            // 3) added the extension
            var completedFileName = 
            $"{Path.GetFileNameWithoutExtension(inprogressFilePath)}--{Guid.NewGuid()}{extension}\n";
            Console.Write(completedFileName);
            completedFileName = Path.ChangeExtension(completedFileName,".complete");
            var completedFilepath = Path.Combine(completedDirectorypath,completedFileName);
            File.Move(inprogressFilePath,completedFilepath,true);
            Console.WriteLine("File Moved");
            var inprogressdirdectoryPath = Path.GetDirectoryName(inprogressFilePath);
            Console.WriteLine(inprogressdirdectoryPath);

            // this will delete the diretory and recursievely all the contents
            Directory.Delete(inprogressdirdectoryPath,true);


       

        }
        public void ProcessTextFile(string inprogressFilePath){
            Console.WriteLine($"Processing text File");
        }


       
        
    }
}
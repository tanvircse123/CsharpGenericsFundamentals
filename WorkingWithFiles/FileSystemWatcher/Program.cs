using System.Collections.Concurrent;
using FileSystemWatchers;


ConcurrentDictionary<string,string> FilesToProcess = new ConcurrentDictionary<string, string>();
// dictionary does not have duplicate 
// value so we store the process in the dictionary 
// then loop through it and Process it
// and then remove it from the dictionary

Console.WriteLine("parsing Command Line Options");
var directorytowatch = args[0];
if(!Directory.Exists(directorytowatch)){
    Console.WriteLine("Directory does not exist");
    return;
}
using var inputFileWatcher = new FileSystemWatcher(directorytowatch);
using var timer = new Timer(processFiles,null,0,1000);
inputFileWatcher.IncludeSubdirectories = false;
inputFileWatcher.InternalBufferSize = 32768;
inputFileWatcher.Filter = "*.*";
inputFileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;


inputFileWatcher.Created += FileCreated;
inputFileWatcher.Deleted += FileDeleted;
inputFileWatcher.Changed += FileChanged;
inputFileWatcher.Error += Errors;
inputFileWatcher.Renamed += FileRenamed;

inputFileWatcher.EnableRaisingEvents = true;
Console.ReadLine();

void FileCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("File Created");
    FilesToProcess.TryAdd(e.FullPath,e.FullPath);
}



void FileChanged(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("File Changed");
    FilesToProcess.TryAdd(e.FullPath,e.FullPath);
}



void FileRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File Renamed From {e.OldName} to {e.Name} ");
    FilesToProcess.TryAdd(e.FullPath,e.FullPath);

}


void FileDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("File Deleted");
}


void Errors(object sender, ErrorEventArgs e)
{
    Console.WriteLine("Error Occured");
}


void processFiles( object stateinfo){

    // now execute this method in a interval 
    // we will use timer for this

    foreach(var filename in FilesToProcess.Keys){
        if(FilesToProcess.TryRemove(filename,out _))
        {
            var fileProcessor = new FileProcessor(filename);
            fileProcessor.Process();
        }
    }
}





static void ProcessSingleFile(string filepath){
	var fileProcessor = new FileProcessor(filepath);
	fileProcessor.Process();
}

static void ProcessDirectory(string directoryPath,string filetype){
	 // get all the file of a spexfic extension
	switch(filetype)
	{
		case "TEXT":
		   var textfiles = Directory.GetFiles(directoryPath,"*.txt");
		   foreach(var itempath in textfiles){
				var fileprocessor = new FileProcessor(itempath);
				fileprocessor.Process();

		   }
		   break;
		default:
			Console.WriteLine($"ERROR: {filetype} is not supported");
			return;
	}
}

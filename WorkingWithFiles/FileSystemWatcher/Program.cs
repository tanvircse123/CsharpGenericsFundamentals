using FileSystemWatchers;

Console.WriteLine("parsing Command Line Options");
var directorytowatch = args[0];
if(!Directory.Exists(directorytowatch)){
    Console.WriteLine("Directory does not exist");
    return;
}
using var inputFileWatcher = new FileSystemWatcher(directorytowatch);
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
    ProcessSingleFile(e.FullPath);
}



void FileChanged(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("File Changed");
    ProcessSingleFile(e.FullPath);
}



void FileRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File Renamed From {e.OldName} to {e.Name} ");
    ProcessSingleFile(e.FullPath);

}


void FileDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("File Deleted");
}


void Errors(object sender, ErrorEventArgs e)
{
    Console.WriteLine("Error Occured");
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

using WorkingWithFiles;

Console.Write("Parsing Command Line options");
var directorytowatch = args[0];
if(!Directory.Exists(directorytowatch)){
	Console.WriteLine($"{directorytowatch} does not exist");
}else{
	Console.WriteLine("Watching directory for changes");

	using var inputfilewatcher = new FileSystemWatcher(directorytowatch);
	inputfilewatcher.IncludeSubdirectories = false;
	inputfilewatcher.InternalBufferSize = 32768;
	inputfilewatcher.Filter = "*.*";
	inputfilewatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;



	// adding event with all the create changed deleted and renamed and error
	inputfilewatcher.Created += FileCreated;
	inputfilewatcher.Changed += FileChanged;
	inputfilewatcher.Deleted += FileDeleted;
	inputfilewatcher.Renamed += FileRenamed;
	inputfilewatcher.Error += WatcherError;

    inputfilewatcher.EnableRaisingEvents = true;
	Console.ReadLine();


	

}

void WatcherError(object sender, ErrorEventArgs e)
{
    Console.WriteLine("Error Occured");
}

void FileRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File Name Changed From {e.OldName} to {e.Name}");
}
void FileDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File Deleted {e.Name}");
}

void FileChanged(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"Content Of the File Changed");
}

void FileCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File Created {e.Name}");
	Console.WriteLine("Processing Begin");
	ProcessSingleFile(e.FullPath); // it will start the procesing the File
}

static void ProcessSingleFile(string filepath){
	var fileProcessor = new FileProcessor(filepath);
	fileProcessor.Process();
}

static void ProcessDirectory(string directoryPath, string filetype){
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
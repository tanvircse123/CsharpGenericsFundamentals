using WorkingWithFiles;

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
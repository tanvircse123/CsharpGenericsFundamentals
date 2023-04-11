using WorkingWithFiles;
var command = args[0];
if (command == "--file"){
	var filepath = args[1];
	// checking if the path fully qualified
	if(!Path.IsPathFullyQualified(filepath)){
		Console.WriteLine($"ERROR: path {filepath} is not fully Qualified");
		Console.ReadLine();
		return;
	}


	Console.WriteLine($"Single {filepath} File Selected");
	ProcessSingleFile(filepath);
}
else if(command == "--dir"){
	var directoryPath = args[1];
	var filetype = args[2];
	Console.WriteLine($"Directory {directoryPath} selected for {filetype} files");
	//ProcessDirectory(directoryPath,filetype);
}else{
	Console.WriteLine("Invalid Command line options");
	Console.ReadLine();
}


static void ProcessSingleFile(string filepath){
	var fileProcessor = new FileProcessor(filepath);
	fileProcessor.Process();
}

static void ProcessDirectory(){

}
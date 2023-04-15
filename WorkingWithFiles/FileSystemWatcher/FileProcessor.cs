using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemWatchers
{
    public class FileProcessor
    {
        private string _InputFilepath;

        public FileProcessor(string Filepath)
        {
            _InputFilepath = Filepath;
        }

        public void Process(){
            if(!File.Exists(_InputFilepath)){
                Console.WriteLine("File does not exist");
                return;
            }
            
            
            var rootDirectory = new DirectoryInfo(_InputFilepath);
            var rootDirectoryName = rootDirectory.Parent.Parent.FullName;

            // create  Diretory
            var backupdirectorypath = CreateDirectory(rootDirectoryName,"backup");
            var processingDirectoryPath = CreateDirectory(rootDirectoryName,"processing");
            var completedDirectoryPath = CreateDirectory(rootDirectoryName,"completed");

            // backupfilepath
            var fileName = Path.GetFileName(_InputFilepath);
            var backupFilePath = CreateFilePath(backupdirectorypath,fileName);
            File.Copy(_InputFilepath,backupFilePath,true);
            

            // in progress filepath
            var inprogressFilePath = CreateFilePath(processingDirectoryPath,fileName);
            File.Move(_InputFilepath,inprogressFilePath,true);
            
            
            // completed work
            var afterprocessFileName = InprogressWork(inprogressFilePath);
            var completedFilePath = CreateFilePath(completedDirectoryPath,afterprocessFileName);
            File.Move(inprogressFilePath,completedFilePath);

            // delete in progress directory
            Directory.Delete(processingDirectoryPath,true);


        }

        public static string  CreateDirectory(string rootdirPath,string directoryName){
            var directoryPath = Path.Combine(rootdirPath,directoryName);
            if(!Directory.Exists(directoryPath)){
                Directory.CreateDirectory(directoryPath);
            }
            return directoryPath;
            
        }

        public static string CreateFilePath(string directoryPath,string FileName){
            var filePath = Path.Combine(directoryPath,FileName);
            return filePath;
        }

        public static string InprogressWork(string inprogressFilePath){
            var extension = Path.GetExtension(inprogressFilePath);
            switch (extension){
                case ".txt":
                ProcessTextFile(inprogressFilePath);
                break;

                default:
                Console.WriteLine("Extension is not supported");
                break;
            }
            var completedFileName = $"{Path.GetFileNameWithoutExtension(inprogressFilePath)}--{Guid.NewGuid()}{extension}";
            completedFileName = Path.ChangeExtension(completedFileName,".complete");
            return completedFileName;

                
                

        }

        private static void ProcessTextFile(string inprogressFilePath)
        {
            var getFileName = Path.GetFileName(inprogressFilePath);
            Console.WriteLine($"Processing File {getFileName}");
        }
    }
}
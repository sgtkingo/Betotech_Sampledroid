using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class PropertiesManager
    {
        public string currentDirectory="";
        public const string pathSettingFiles=@"\settings\";
        public const string namePathFile="pathFile.path";

        public string primalFileType=".CSV";

        private const string inPathMark="INPATH";
        private const string outPathMark="OUTPATH";
        private const char splitPathMark='-';

        public VirtualFile pathFile;

        public string pathIN{ get;set; }
        public string pathOUT{ get;set; }

        private FileManager FileManager;
        private ConsoleBox ConsoleBox;

        public PropertiesManager(ConsoleBox console, FileManager fileManager){
            FileManager=fileManager;
            ConsoleBox=console;

            currentDirectory=Directory.GetCurrentDirectory();
            pathIN=currentDirectory;
            pathOUT=currentDirectory;
            pathFile=new VirtualFile();
            pathFile.appendFile(currentDirectory+pathSettingFiles+namePathFile);
            checkDirectory();
            reloadPathFile();
        }

        private void checkDirectory(){ 
            if(!Directory.Exists(currentDirectory+pathSettingFiles)){ 
                Directory.CreateDirectory(currentDirectory+pathSettingFiles);
                ConsoleBox.WriteLineToConsole("Settings directory create!");
            }else ConsoleBox.WriteLineToConsole("Setting directory check: OK.");
        }

        private void parsePathFile(){
            string[] splitData=(pathFile.FILEDATA).Split('\n');
            int index=0;
            foreach(string line in splitData){
                if(line.Contains(inPathMark)){
                    index=line.LastIndexOf(splitPathMark);
                    try{ pathIN=line.Substring(index+1); } 
                    catch (Exception e){ 
                        pathIN=currentDirectory;
                        Console.WriteLine(e.ToString()); 
                     }
                } 
                if(line.Contains(outPathMark)){
                    index=line.LastIndexOf(splitPathMark);
                    try{ pathOUT=line.Substring(index+1); }
                    catch (Exception e){ 
                        pathOUT=currentDirectory;
                        Console.WriteLine(e.ToString()); 
                     }
                }                  
            }
            ConsoleBox.WriteLineToConsole("Path file reloaded!");
        }

        public void reloadPathFile(){
            if(FileManager.LoadFile(pathFile)){
                parsePathFile();
            }
            else ConsoleBox.WriteLineToConsole("Path file doesnt exist yet...");
            ConsoleBox.WriteLineToConsole("INPUT DIRECTORY: "+pathIN);
            ConsoleBox.WriteLineToConsole("OUTPUT DIRECTORY: "+pathOUT);
        }

        private void fillPathFile()
        {
            string data="";
            data+=inPathMark+splitPathMark+pathIN;
            data+="\n";
            data+=outPathMark+splitPathMark+pathOUT;
            data+="\n";
            pathFile.FILEDATA=data;
        }

        public void savePathFile(){ 
            fillPathFile();
            if(FileManager.SaveFile(pathFile)){ 
                ConsoleBox.WriteLineToConsole("Path file refresh..");
            }
        }
    }
}

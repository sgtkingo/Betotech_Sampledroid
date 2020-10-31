using System;
using System.Collections.Generic;
using System.IO;

namespace ConcreteSampleTransformers
{
    public class FileManager
    {
        public static bool LoadFile(VirtualFile virtualFile){ 
            if(virtualFile == null)return false;

            virtualFile.clearFileData();
            string data = string.Empty;

            if (!File.Exists(virtualFile.FILEPATH))
            {
                Processer.ConsoleBox.WriteLineToConsole("FILE DOESNT EXIST!");
                return false;
            }
            try{ 
                using (FileStream fs = new FileStream(virtualFile.FILEPATH,FileMode.Open))
                {
                fs.Seek(0,SeekOrigin.Begin);
                    StreamReader sr=new StreamReader(fs);

                    while(!sr.EndOfStream){ 
                        data += sr.ReadLine();
                        data += "\n";
                    }

                    sr.Close();
                    fs.Close();
                }               
            }catch (Exception e){ 
                Processer.ConsoleBox.WriteLineToConsole("FILE OPEN ERROR...");
                Processer.ConsoleBox.WriteLineToConsole($"PROBLEM: {e.Message} | {e.Source} ");
                return false;
            }
            virtualFile.fillFile(data);
            Processer.ConsoleBox.WriteLineToConsole("FILE "+virtualFile.FILENAME+" LOADED!");
            return true;
        }

        public static bool SaveFile(VirtualFile virtualFile){
            if(virtualFile == null)return false;

            string filePath=(virtualFile.FILEPATH);
            try{ 
                using (FileStream fs = new FileStream(filePath,FileMode.Create))
                {
                fs.Seek(0,SeekOrigin.Begin);
                    StreamWriter sw=new StreamWriter(fs);
                    sw.Write(virtualFile.getFileData());
                    sw.Close();
                    fs.Close();
                }               
            }catch (Exception e){ 
                Processer.ConsoleBox.WriteLineToConsole("FILE SAVE ERROR...");
                Processer.ConsoleBox.WriteLineToConsole($"PROBLEM: {e.Message} | {e.Source} ");
                return false;
                }
            Processer.ConsoleBox.WriteLineToConsole("FILE "+virtualFile.FILENAME+" SAVED!");
            return true;
        }
    }
}

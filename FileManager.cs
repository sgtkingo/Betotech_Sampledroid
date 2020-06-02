using System;
using System.IO;

namespace ConcreteSampleTransformers
{
    public class FileManager
    {
        public bool LoadFile(VirtualFile virtualFile){ 
            virtualFile.FILEDATA="";
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
                        virtualFile.FILEDATA+=sr.ReadLine();
                        virtualFile.FILEDATA+="\n";
                    }

                    sr.Close();
                    fs.Close();
                }               
            }catch (Exception e){ 
                Processer.ConsoleBox.WriteLineToConsole("FILE OPEN ERROR...");
                Processer.ConsoleBox.WriteLineToConsole("CODE:"+e.ToString());
                return false;
                }
            Processer.ConsoleBox.WriteLineToConsole("FILE "+virtualFile.FILENAME+" LOADED!");
            return true;
        }

        public bool SaveFile(VirtualFile virtualFile){
            string filePath=(virtualFile.FILEPATH);
            try{ 
                using (FileStream fs = new FileStream(filePath,FileMode.Create))
                {
                fs.Seek(0,SeekOrigin.Begin);
                    StreamWriter sw=new StreamWriter(fs);
                    sw.Write(virtualFile.FILEDATA);
                    sw.Close();
                    fs.Close();
                }               
            }catch (Exception e){ 
                Processer.ConsoleBox.WriteLineToConsole("FILE SAVE ERROR...");
                Processer.ConsoleBox.WriteLineToConsole("CODE:"+e.ToString());
                return false;
                }
            Processer.ConsoleBox.WriteLineToConsole("FILE "+virtualFile.FILENAME+" SAVED!");
            return true;
        }

    }
}

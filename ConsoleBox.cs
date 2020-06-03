using System.IO;
using System.Windows.Forms;

namespace ConcreteSampleTransformers
{
    public class ConsoleBox
    {
        public enum LineType{ Normal='-', Bold='•', Star='*'}

        RichTextBox MyConsoleBox;
        public ConsoleBox(RichTextBox C){
            MyConsoleBox=C;
            MyConsoleBox.ReadOnly=true;
            MyConsoleBox.TextChanged += (sender, e) =>
            {
                MyConsoleBox.SelectionStart = MyConsoleBox.TextLength;
                MyConsoleBox.ScrollToCaret();
            };
            this.WriteLineToConsole("Console READY!");
        }
        public void WriteLineToConsole(string text){ 
            MyConsoleBox.AppendText(text+"\n");
            this.Line();
        }
        public void WriteLineToConsole(string text, LineType T){ 
            MyConsoleBox.AppendText(text+"\n");
            this.Line((char)T);
        }
        public void WriteToConsole(string text){ 
            MyConsoleBox.Text+=text;
        }
        public void Line(char C='-', int LENGHT=45){ 
            string txt="";
            for(int i=0;i<LENGHT;i++){ 
                txt+=C;
            }
            txt+="\n";
            this.WriteToConsole(txt);
        }
        public void ClearConsole(){ 
            MyConsoleBox.Clear();
        }
        public void SaveToFile(string file){ 
            string path =PropertiesManager.currentDirectory+PropertiesManager.pathLocalReportsFiles+file+PropertiesManager.primalReportType;
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                //Create the file.
                using (FileStream fs = new FileStream(path,FileMode.Create))
                {
                    fs.Seek(0,SeekOrigin.Begin);
                        StreamWriter sw=new StreamWriter(fs);
                        sw.Write(MyConsoleBox.Text);

                        sw.Close();
                        fs.Close();
                }               
        }
    }
}

using System.IO;
using System.Windows.Forms;

using ControlModul.FileControl;

namespace ConcreteSampleTransformers
{
    public class ConsoleBox
    {
        public enum LineType{ Normal='-', Bold='•', Star='*', NoLine = 0}
        public enum MessageType { None, Info, Warning, Error }

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
        private void WriteToConsole(string text){
            MyConsoleBox.AppendText(text + "\n");
        }
        public void Line(char C='-', int LENGHT=40){
            if (C == 0) return;

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
            string path =PropertiesManager.currentDirectoryPath+PropertiesManager.reportDataPath+file+PropertiesManager.fileTypeReport;
            VirtualFile virtualFile=new VirtualFile();
            virtualFile.AppendFile(path, false);
            virtualFile.FillFile(MyConsoleBox.Text);
            virtualFile.SaveFile();
        }
    }
}

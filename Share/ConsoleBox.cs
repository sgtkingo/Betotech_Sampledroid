using System;
using System.Drawing;
using System.Windows.Forms;

using ControlModul.FileControl;

namespace ConcreteSampleTransformers
{
    //Output console: short colored messages, narrow box friendly (~30 chars per line)
    public class ConsoleBox
    {
        public enum MessageType { Info, Detail, Success, Warning, Error }

        private const char SeparatorChar = '─';
        private const int PrefixLength = 2; //"√ ", "× ", ...

        private static readonly Color InfoColor = SystemColors.WindowText;
        private static readonly Color DetailColor = Color.Gray;
        private static readonly Color SuccessColor = Color.ForestGreen;
        private static readonly Color WarningColor = Color.DarkOrange;
        private static readonly Color ErrorColor = Color.Firebrick;
        private static readonly Color HeaderColor = Color.SteelBlue;

        RichTextBox MyConsoleBox;
        public ConsoleBox(RichTextBox C){
            MyConsoleBox=C;
            MyConsoleBox.ReadOnly=true;
            MyConsoleBox.WordWrap=true;
            MyConsoleBox.TextChanged += (sender, e) =>
            {
                MyConsoleBox.SelectionStart = MyConsoleBox.TextLength;
                MyConsoleBox.ScrollToCaret();
            };
        }

        public void Info(string text) { Write(MessageType.Info, text); }
        public void Detail(string text) { Write(MessageType.Detail, text); }
        public void Success(string text) { Write(MessageType.Success, text); }
        public void Warning(string text) { Write(MessageType.Warning, text); }
        public void Error(string text) { Write(MessageType.Error, text); }

        public void Write(MessageType type, string text)
        {
            switch (type)
            {
                case MessageType.Detail: Append("  " + text, DetailColor, false); break;
                case MessageType.Success: Append("√ " + text, SuccessColor, false); break;
                case MessageType.Warning: Append("! " + text, WarningColor, false); break;
                case MessageType.Error: Append("× " + text, ErrorColor, false); break;
                default: Append("  " + text, InfoColor, false); break;
            }
        }

        //Width of one character of console font (monospace) in pixels
        private int CharWidth
        {
            get { return Math.Max(1, TextRenderer.MeasureText(new string('0', 10), MyConsoleBox.Font).Width / 10); }
        }

        //Number of characters fitting into one console line (without scrollbar)
        private int LineLength
        {
            get
            {
                int width = MyConsoleBox.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4;
                return Math.Max(10, width / CharWidth - 1);
            }
        }

        //Section title: "── TITLE ─────"
        public void Header(string title)
        {
            string head = $"{SeparatorChar}{SeparatorChar} {title} ";
            Append(head.PadRight(LineLength, SeparatorChar), HeaderColor, true);
        }

        //Start of new block (e.g. processed file): separator + bold title
        public void Title(string title)
        {
            Separator();
            Append("► " + title, InfoColor, true);
        }

        public void Separator()
        {
            Append(new string(SeparatorChar, LineLength), DetailColor, false);
        }

        private void Append(string text, Color color, bool bold)
        {
            MyConsoleBox.SelectionStart = MyConsoleBox.TextLength;
            MyConsoleBox.SelectionLength = 0;
            MyConsoleBox.SelectionColor = color;
            MyConsoleBox.SelectionFont = new Font(MyConsoleBox.Font, bold ? FontStyle.Bold : FontStyle.Regular);
            //Wrapped lines continue under the text, not under the prefix
            MyConsoleBox.SelectionHangingIndent = PrefixLength * CharWidth;
            MyConsoleBox.AppendText(text + "\n");
            MyConsoleBox.SelectionColor = MyConsoleBox.ForeColor;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class ErrorManager
    {
        private const string messageOK = "ALL OK :)";
        private const string messageERROR = "ERRORs FOUND!";
        private const string messageFAIL = "FAIL!!!";
        public string FinalMessage { get; private set; }

        Storage _Storage;
        ConsoleBox _ConsoleBox;

        private List<Error> errors = new List<Error>();

        public ErrorManager(Storage storage, ConsoleBox consoleBox){
            _Storage = storage;
            _ConsoleBox = consoleBox;
        }

        public void Add(Error e){
            errors.Add(e);
        }

        public int GetNumberOfERRORs() { return errors.Count; }
        public List<Error> GetERRORs() { return errors; }

        public void Clear(){ errors.Clear(); }

        public bool CheckERRORs()
        {
            bool result = true;
            string output = "";

            _ConsoleBox.WriteLineToConsole("\t***ERROR CONTROL***", ConsoleBox.LineType.Bold);
            FinalMessage = messageOK;
            if (errors.Count > 0)
            {
                errors.Add(new Error("WARNING", "FIND ERRORS!", (errors.Count).ToString()));
                FinalMessage = messageERROR;
                result = false;
            }
            if (_Storage.GetNumberOfBadSamples() > 0)
            {
                errors.Add(new Error("ERROR", "FIND SOME BAD SAMPLES", _Storage.GetNumberOfBadSamples().ToString()));
                FinalMessage = messageFAIL;
                result = false;
            }
            if (_Storage.isStorageEmpty())
            {
                errors.Add(new Error("ERROR", "NO SAMPLES FOUND!", (errors.Count).ToString()));
                FinalMessage = messageFAIL;
                result = false;
            }
            //Fill output info
            output += "Number of corrupt samples: " + _Storage.GetNumberOfBadSamples();
            output += "\n";
            foreach (Sample S in _Storage.GetBadSamples())
            {
                output += "CORRUPT SAMPLE: " + S.sampleCode;
                output += "\n";
            }
            //output += "\n";
            output += "Number of erros and warnings: " + errors.Count;
            output += "\n";
            foreach (Error E in this.errors)
            {
                output += E.ToString();
                output += "\n";
            }
            _ConsoleBox.WriteLineToConsole(output);
            _ConsoleBox.WriteLineToConsole("Final result: "+FinalMessage, ConsoleBox.LineType.Bold);

            return result;
        }
    }
}

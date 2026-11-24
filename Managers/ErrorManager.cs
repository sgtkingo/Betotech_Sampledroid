using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class ErrorManager
    {
        private const string messageOK = "ALL OK";
        private const string messageERROR = "ERRORS FOUND";
        private const string messageFAIL = "FAILED";
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
            int badSamples = _Storage.GetNumberOfBadSamples();
            bool noSamples = _Storage.isStorageEmpty();

            //List problems found while parsing
            foreach (Error E in errors)
            {
                if (E.ErrorType == "WARNING") _ConsoleBox.Warning(E.ToString());
                else _ConsoleBox.Error(E.ToString());
            }
            foreach (Sample S in _Storage.GetBadSamples())
            {
                _ConsoleBox.Error($"{S.sampleCode}: corrupt sample");
            }
            if (noSamples)
            {
                _ConsoleBox.Error("no samples found");
            }

            int problems = errors.Count + badSamples + (noSamples ? 1 : 0);
            bool result = problems == 0;

            if (result) FinalMessage = messageOK;
            else if (noSamples || badSamples > 0) FinalMessage = messageFAIL;
            else FinalMessage = messageERROR;

            _ConsoleBox.Header("RESULT");
            if (result)
            {
                _ConsoleBox.Success(FinalMessage);
            }
            else
            {
                _ConsoleBox.Error($"{FinalMessage} ({problems} problem{(problems == 1 ? "" : "s")})");
                FinalMessage += $"\n{problems} problem{(problems == 1 ? "" : "s")} - see console.";
            }

            return result;
        }
    }
}

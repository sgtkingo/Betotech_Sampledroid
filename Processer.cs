
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ConcreteSampleTransformers.Managers;

namespace ConcreteSampleTransformers
{
    public class Processer
    {
        // Get current culture's NumberFormatInfo object.
        public static NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;

        //Patterns
        private const string codePattern = @"[0-9]+/[0-9]+/[0-9]+"; //recognize code pattern
        private const string datePattern = @"(\d{2}\.\d{2}\.\d{4})+"; //recognize date pattern
        private const string dataCubePattern = @"(;\d+\.?\d*){7}"; //recognize data Cube pattern
        private const string dataCylinderPattern = @"(;\d+\.?\d*){6}"; //recognize data Cylinder pattern

        public Storage Storage { get; private set; }
        public DatabaseManager DatabaseManager{ get; private set; }
        public FileManager FileManager { get; private set; }
        public FileMaker FileMaker { get; private set; }
        public ErrorManager ErrorManager { get; private set; }
        public StatsManager StatsManager { get; private set; }
        public ViewerManager ViewerManager { get; private set; }

        public bool Result { get; private set; }
        public DateTime LastTimeStamp { get; private set; }

        public static ConsoleBox ConsoleBox;

        public Processer(RichTextBox BOX){ 

            ConsoleBox=new ConsoleBox(BOX);
            PropertiesManager.Init();

            Storage =new Storage();
            DatabaseManager = new DatabaseManager(PropertiesManager.connectionString);
            ErrorManager = new ErrorManager(Storage, ConsoleBox);
            StatsManager = new StatsManager(Storage, ConsoleBox);
            FileManager = new FileManager();
            FileMaker= new FileMaker(Storage, DatabaseManager);
            ViewerManager = new ViewerManager(Storage);

            ConsoleBox.WriteLineToConsole("\tPROGRAM READY!",ConsoleBox.LineType.Bold);
        }
        private Sample TransformSample(TypesEnums.SampleType T,Sample Prototype){
            Sample S=null;
            if(T==TypesEnums.SampleType.Cube)S=new CubeSample(Prototype.sampleCode,Prototype.sampleDate);
            if(T==TypesEnums.SampleType.Cylinder)S=new CylinderSample(Prototype.sampleCode,Prototype.sampleDate); 
            return S;
        }
        private Sample CreateNewSample(string code){
            return new PrototypeSample(code);
        }
        private void FillSample(Sample S, string data, int ABC){
           if(S==null)return;
           if(S.getType==TypesEnums.SampleType.Cube)
            {
              CubeSample cube=(CubeSample)S;
              cube.FillSample(data,ABC);
            }
           if (S.getType == TypesEnums.SampleType.Cylinder)
            {
                CylinderSample cylinder = (CylinderSample)S;
                cylinder.FillSample(data, ABC);
            }
        }
        private string cutDate(string data){ 
            string date="";
            string[] parts=data.Split(';');

            if (parts.Length > 3){
                if(RecognizeDate(parts[3])){ 
                    date=parts[3];
                }
            }
            return date;
        }
        private bool RecognizeCode(string data){ 
            return Regex.IsMatch(data,codePattern);
        }
        private bool RecognizeDate(string data){ 
            return Regex.IsMatch(data,datePattern);
        }
        private TypesEnums.SampleType RecognizeData(string data){
            if (Regex.IsMatch(data,dataCubePattern)){
                return TypesEnums.SampleType.Cube;
            }
            if (Regex.IsMatch(data,dataCylinderPattern)){
                return TypesEnums.SampleType.Cylinder;
            }
            return TypesEnums.SampleType.NoType;
        }
        private bool ParseSamples(string data){
            Storage.ClearStorage();
            ErrorManager.Clear();

            Sample S=null;
            string actualCode="";
            TypesEnums.SampleType actualType;

            int N_ABC=0;
            int line_number=0;
            string[] Lines=data.Split('\n');

            ConsoleBox.WriteLineToConsole($"Start parsing [{Lines.Length}] lines...", ConsoleBox.LineType.NoLine);

            foreach (string line in Lines){
                line_number++;
                if(RecognizeCode(line)){
                    if(S!=null)if(S.getType==TypesEnums.SampleType.NoType){ ErrorManager.Add(new Error("ERROR","S is PROTOTYPE!",S.sampleCode)); }
                    //Storage.SaveSample(S);
                    actualCode=line;
                    S=CreateNewSample(actualCode);
                    continue;
                }
                else if(RecognizeDate(line)){
                    if(S!=null)S.sampleDate=cutDate(line);
                    continue;
                }
                else if((actualType=RecognizeData(line))!=TypesEnums.SampleType.NoType){ 
                    if(S==null){
                        ErrorManager.Add(new Error("ERROR","S == null",line_number.ToString()));
                        continue;
                    }
                    if(S.getType==TypesEnums.SampleType.NoType){ 
                        S=TransformSample(actualType,S);
                        N_ABC=0;
                    }
                    N_ABC++; 
                    FillSample(S,line,N_ABC);
                } 
                if(S!=null){ 
                    if(S.getType!=(int)TypesEnums.SampleType.NoType){
                        Storage.SaveSample(S);
                    }
                }
            }
            ConsoleBox.WriteLineToConsole("Parsing complete...");
            return CheckForERRORs();    
        }

        private string PrepareDataForProcess(VirtualFile virtualFile)
        {
            if (!FileManager.LoadFile(virtualFile)) return string.Empty;
            return virtualFile.getFileData();
        }

        private void DoProcess(string data)
        {
            ConsoleBox.WriteLineToConsole("Start proccess...", ConsoleBox.LineType.NoLine);
            Result = ParseSamples(data);
            LastTimeStamp = DateTime.Now;
        }
        public void MakeSamples(VirtualFile virtualFile){
            string data = PrepareDataForProcess(virtualFile);
            DoProcess(data);
        }  
        
        public bool MakeFiles(){
            return FileMaker.MakeFiles(PropertiesManager.ActualFileType);
        }
        
        public List<Error> getERRORs(){return ErrorManager.GetERRORs();}

        public string GetFinalMessage() {
            return ErrorManager.FinalMessage;
        }

        public bool CheckForERRORs(){
            return ErrorManager.CheckERRORs();
        }

        public void FlushStats(){
            StatsManager.GenerateStats();
        }

        /*public void Test_FILE(VirtualFile virtualFile){
            FileManager.LoadFile(virtualFile);
            virtualFile.FILETYPE=".txt";
            FileManager.SaveFile(virtualFile);
            ConsoleBox.WriteLineToConsole("DONE");
        }

        public void Test_Convert(VirtualFile virtualFile){
            if(MakeSamples(virtualFile)){ 
                foreach(Sample S in Storage.GetAllSamples()){ 
                    ConsoleBox.WriteLineToConsole(S.sampleCode);
                }
                ConsoleBox.WriteLineToConsole("OK");
            }else ConsoleBox.WriteLineToConsole("ERROR");
        }

        public void Test_ALL(VirtualFile virtualFile){
            if(MakeSamples(virtualFile()){
                if(MakeFile(virtualFile)){
                    ConsoleBox.WriteLineToConsole("PROCESS DONE!");    
                }
            }    
        }*/
    }
}

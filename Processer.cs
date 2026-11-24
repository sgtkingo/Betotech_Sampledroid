
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ConcreteSampleTransformers.Managers;

using ControlModul.FileControl;

namespace ConcreteSampleTransformers
{
    public class Processer
    {
        // Get current culture's NumberFormatInfo object.
        public static NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;

        //Patterns
        private const string codePattern = @"[0-9]+/[0-9]+/[0-9]+"; //recognize code pattern (123/45678/20)
        private const string numericCodePattern = @"^[0-9]{4,}$"; //recognize code as standalone number on its own line (2602755)
        private const string zeroValuePattern = @"^0*([.,]0*)?$"; //recognize zero value (0, 0.0, 0,000)
        private const string datePattern = @"(\d{1,2}\.\d{1,2}\.\d{4})+"; //recognize date pattern (01.04.2020 or 1.4.2020)
        private const string dataCubePattern = @"(;\d+([.,]\d*)?){7}"; //recognize data Cube pattern (decimal '.' or ',')
        private const string dataCylinderPattern = @"(;\d+([.,]\d*)?){6}"; //recognize data Cylinder pattern (decimal '.' or ',')

        //Internal field separator used by parser and output files (input separator is chosen in Settings)
        public const char FieldSeparator = ';';

        public Storage Storage { get; private set; }
        public DataManager DataManager{ get; private set; }
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
            DataManager = new DataManager(PropertiesManager.connectionString);
            ErrorManager = new ErrorManager(Storage, ConsoleBox);
            StatsManager = new StatsManager(Storage, ConsoleBox);
            FileMaker= new FileMaker(Storage, DataManager);
            ViewerManager = new ViewerManager(Storage);

            ConsoleBox.Header($"SAMPLEDROID {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");
            WriteSettingsSummary();
            ConsoleBox.Success("Ready - open file");
        }

        //Short overview of settings affecting the result
        public void WriteSettingsSummary()
        {
            ConsoleBox.Detail($"In : dec '{PropertiesManager.inputNfiSeparator}'  col {SeparatorName(PropertiesManager.inputFieldSeparator)}");
            ConsoleBox.Detail($"Out: dec '{PropertiesManager.outputNfiSeparator}'  col {SeparatorName(PropertiesManager.outputFieldSeparator)}");
            ConsoleBox.Detail($"Density calc: {(PropertiesManager.computeObjHmotnost ? "ON" : "OFF")}");
            if (!PropertiesManager.IsValidDirectory(PropertiesManager.outputDataPath))
            {
                ConsoleBox.Warning("Output folder not set");
            }
        }

        private static string SeparatorName(char separator)
        {
            return separator == '\t' ? "TAB" : $"'{separator}'";
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
            string[] parts=data.Split(FieldSeparator);

            if (parts.Length > 3){
                if(RecognizeDate(parts[3])){ 
                    date=parts[3];
                }
            }
            return date;
        }
        private bool RecognizeCode(string data){
            return Regex.IsMatch(data,codePattern) || Regex.IsMatch(data,numericCodePattern);
        }
        //Returns only the field that holds the sample code (drops ";;;" padding from CSV exports)
        private string CutCode(string data){
            foreach (string part in data.Split(FieldSeparator)){
                if (Regex.IsMatch(part, codePattern) || Regex.IsMatch(part, numericCodePattern)) return part;
            }
            return data;
        }
        //Measurement line with all values zero = aborted/empty test, it carries no data
        private bool IsEmptyMeasurement(string data){
            string[] parts = data.Split(FieldSeparator);
            for (int i = 1; i < parts.Length; i++){
                if (!Regex.IsMatch(parts[i], zeroValuePattern)) return false;
            }
            return true;
        }
        //Unify input line: strip line ending/BOM, convert input field separator (Settings) to ';', trim spaces and quotes of each field
        private string NormalizeLine(string line){
            line = line.Trim('\r', '\n', '﻿');

            string[] parts = line.Split(PropertiesManager.inputFieldSeparator);
            for (int i = 0; i < parts.Length; i++){
                parts[i] = parts[i].Trim().Trim('"').Trim();
            }
            return string.Join(FieldSeparator.ToString(), parts);
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

            int lineCount = data.TrimEnd('\r', '\n').Split('\n').Length;
            ConsoleBox.Detail($"{lineCount} line{(lineCount == 1 ? "" : "s")} loaded");

            foreach (string rawLine in Lines){
                line_number++;
                string line = NormalizeLine(rawLine);
                if(RecognizeCode(line)){
                    if(S!=null)if(S.getType==TypesEnums.SampleType.NoType){ ErrorManager.Add(new Error("ERROR","no measurement data",S.sampleCode)); }
                    //Storage.SaveSample(S);
                    actualCode=CutCode(line);
                    S=CreateNewSample(actualCode);
                    continue;
                }
                else if(RecognizeDate(line)){
                    if(S!=null)S.sampleDate=cutDate(line);
                    continue;
                }
                else if((actualType=RecognizeData(line))!=TypesEnums.SampleType.NoType){
                    if(IsEmptyMeasurement(line)){
                        ConsoleBox.Detail($"L{line_number}: empty test skipped");
                        continue;
                    }
                    if(S==null){
                        ErrorManager.Add(new Error("ERROR","no sample code",$"L{line_number}"));
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
            return CheckForERRORs();
        }

        private string PrepareDataForProcess(VirtualFile virtualFile)
        {
            if (!FileManager.LoadFile(virtualFile)) return string.Empty;
            return virtualFile.GetData();
        }

        private void DoProcess(string data)
        {
            Result = ParseSamples(data);
            LastTimeStamp = DateTime.Now;
        }
        public void MakeSamples(VirtualFile virtualFile){
            ConsoleBox.Title(virtualFile.FILENAME);
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


using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConcreteSampleTransformers
{
    public class Processer
    {
        private const string codePattern = @"[0-9]{3}/[0-9]{5}/[0-9]{2}"; //recognize code pattern
        private const string dataCubePattern = @"\d+(;\d+\.?\d*){7}"; //recognize data Cube pattern
        private const string dataCylinderPattern = @"%%%"; //recognize data Cube pattern
        // Get current culture's NumberFormatInfo object.
        //private NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
        private const string messageOK="PROCESS DONE - NO ERROR";
        private const string messageERROR="PROCESS DONE - ERRORS FOUND!!!";
        private const string messageFAIL="PROCESS DONE - FAIL!!!";

        private string DATA;
        private int ERRORS=0;

        public string FinalMessage{ get;set;}
        public bool Zeroless;

        Storage Storage;
        FileManager FileManager;

        public static ConsoleBox ConsoleBox;
        public static PropertiesManager PropertiesManager;

        private List<Error> errors;

        public Processer(RichTextBox BOX){ 
            DATA="";
            ERRORS=0;
            Zeroless=false;
            errors=new List<Error>();

            ConsoleBox=new ConsoleBox(BOX);
            Storage=new Storage();
            FileManager=new FileManager();

            PropertiesManager=new PropertiesManager(ConsoleBox,FileManager);

            ConsoleBox.WriteLineToConsole("PROGRAM READY!",ConsoleBox.LineType.Bold);
        }
        private Sample TransformSample(TypesEnums.Type T,Sample Prototype){
            Sample S=null;
            if(T==TypesEnums.Type.Cube)S=new CubeSample(Prototype.sampleCode);
            if(T==TypesEnums.Type.Cylinder)S=null; //Cylinder type doest exist yet
            return S;
        }
        private Sample CreateNewSample(string code){
            return new PrototypeSample(code);
        }
        private void FillSample(Sample S, string data, int ABC){
           if(S==null)return;
           if(S.getType==(int)TypesEnums.Type.Cube){
              CubeSample cube=(CubeSample)S;
              cube.FillSample(data,ABC);
           }
        }
        private bool RecognizeCode(string data){ 
            return Regex.IsMatch(data,codePattern);
        }
        private TypesEnums.Type RecognizeData(string data){
            if (Regex.IsMatch(data,dataCubePattern)){
                return TypesEnums.Type.Cube;
            }
            if (Regex.IsMatch(data,dataCylinderPattern)){
                return TypesEnums.Type.Cylinder;
            }
            return TypesEnums.Type.NoType;
        }
        private bool ParseSamples(string data){
            ERRORS=0;
            errors.Clear();
            Storage.ClearStorage();
            Sample S=null;
            string actualCode="";
            TypesEnums.Type actualType;

            int N_ABC=0;
            string[] Lines=data.Split('\n');

            foreach(string line in Lines){
                if(RecognizeCode(line)){
                    if(S!=null)if(S.getType==(int)TypesEnums.Type.NoType){ errors.Add(new Error("ERROR","S is PROTOTYPE!",S.sampleCode)); }
                    Storage.SaveSample(S);
                    actualCode=line;
                    S=CreateNewSample(actualCode);
                    continue;
                }
                else if((actualType=RecognizeData(line))!=TypesEnums.Type.NoType){ 
                    if(S==null){ 
                        errors.Add(new Error("ERROR","S == null",(errors.Count).ToString()));
                        continue;
                    }
                    if(S.getType==(int)TypesEnums.Type.NoType){ 
                        S=TransformSample(actualType,S);
                        N_ABC=0;
                    }
                    N_ABC++; 
                    FillSample(S,line,N_ABC);
                } 
            }
            return printERRORs();    
        }
        public bool MakeSamples(VirtualFile virtualFile){
            if(virtualFile==null)return false;
            DATA="";
            if(!FileManager.LoadFile(virtualFile))return false;
            DATA=virtualFile.FILEDATA;

            return ParseSamples(DATA);    
        }

        public bool MakeFile(VirtualFile virtualFile){
            if(virtualFile==null)return false;
            DATA="";
            foreach(Sample S in Storage.GetAllSamples()){
                DATA+=S.getSampleAsFormatData(Zeroless);
                DATA+="\n";
            }
            virtualFile.FILEDATA=DATA;
            return FileManager.SaveFile(virtualFile);
        }

        public int getNumberOfERRORs(){return ERRORS;}
        public List<Sample> getRRORs(){return Storage.getBadSamples();}

        public bool printERRORs(){
           bool result=true; 
           string output="";
           ERRORS+=errors.Count;
           ERRORS+=Storage.getNumberOfBadSamples();
           if(ERRORS > 0){
                ConsoleBox.WriteLineToConsole("FIND "+ERRORS+" BAD SAMPLES/ERRORS!",ConsoleBox.LineType.Bold);
           }
           if(Storage.getNumberOfSamples() == Storage.getNumberOfBadSamples()){
                errors.Add(new Error("ERROR","ALL SAMPLES ARE CORRUPTED",(errors.Count).ToString()));
                result=false;
           }
           if(Storage.isStorageEmpty()){ 
                errors.Add(new Error("ERROR","NO SAMPLES FOUND!",(errors.Count).ToString()));
                result=false;
           }
               output+="NUMBER OF BAD SAMPLES: "+Storage.getNumberOfBadSamples();
               output+="\n\n";
               foreach(Sample S in Storage.getBadSamples()){
                    output+="CORRUPT SAMPLE: "+S.sampleCode;
                    output+="\n";
               }
               output+="\n";
               output+="NUMBER OF ERRORS: "+errors.Count;
               output+="\n\n";
               foreach(Error E in this.errors){
                    output+=E.ToString();
                    output+="\n";
               }
           ConsoleBox.WriteToConsole(output);
           ConsoleBox.WriteLineToConsole("",ConsoleBox.LineType.Bold);
           
           FinalMessage=messageOK;
           if(ERRORS > 0)FinalMessage=messageERROR;
           if(!result)FinalMessage=messageFAIL;

           return result;
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
            if(MakeSamples(virtualFile)){
                if(MakeFile(virtualFile)){
                    ConsoleBox.WriteLineToConsole("PROCESS DONE!");    
                }
            }    
        }*/
    }
}

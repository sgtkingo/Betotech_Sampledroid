using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class CubeSample : Sample
    {
        public int getType { get; set; }
        public string sampleCode { get; set; }
        public string sampleSimpleCode{ get; set; }
        public string sampleDate { get; set; }

        private bool S1_FOUND=false;
        private string S1_Mark="0";
        private string S1_Mass="0";
        private string S1_Load="0";
        private string S1_Lenght="0";
        private string S1_Width="0";
        private string S1_Height="0";

        private bool S2_FOUND=false;
        private string S2_Mark="0";
        private string S2_Mass="0";
        private string S2_Load="0";
        private string S2_Lenght="0";
        private string S2_Width="0";
        private string S2_Height="0";

        private bool S3_FOUND=false;
        private string S3_Mark="0";
        private string S3_Mass="0";
        private string S3_Load="0";
        private string S3_Lenght="0";
        private string S3_Width="0";
        private string S3_Height="0";

        public CubeSample(string code,string date){ 
            getType=(int)TypesEnums.Type.Cube; 
            sampleCode=code;
            sampleSimpleCode=getSimpleCode();
            sampleDate=date;
        }

        public string getSimpleCode()
        {
            string simple="";
            int last_index=0;
            int first_index=0;
            try{
                last_index=sampleCode.LastIndexOf('/');
                first_index=sampleCode.IndexOf('/');
                simple=sampleCode.Substring(first_index+1,(last_index-first_index)-1);
            }catch(Exception e){ Processer.ConsoleBox.WriteLineToConsole(e.ToString()); simple=""; }
            return simple;
        }

        private string FindAndReplace(string data){
            string output="";
            for(int i=0;i<data.Length;i++){ 
                if(data[i]=='.')output+=',';
                else output+=data[i];
            }
            return output;
        }

        public void FillSample(string data, int ABC){
            string formatData=FindAndReplace(data);
            string[] Parts=formatData.Split(';');
            for(int i=0;i<Parts.Length;i++){
                if(i==5 || i==7)continue;
                if(ABC==1){
                    S1_FOUND=true;
                    if(i==0)S1_Mark=Parts[i];
                    if(i==1)S1_Lenght=Parts[i];
                    if(i==2)S1_Width=Parts[i];
                    if(i==3)S1_Height=Parts[i];
                    if(i==4)S1_Mass=Parts[i];
                    if(i==6)S1_Load=Parts[i];
                }
                if(ABC==2){
                    S2_FOUND=true;
                    if(i==0)S2_Mark=Parts[i];
                    if(i==1)S2_Lenght=Parts[i];
                    if(i==2)S2_Width=Parts[i];
                    if(i==3)S2_Height=Parts[i];
                    if(i==4)S2_Mass=Parts[i];
                    if(i==6)S2_Load=Parts[i];                    
                }
                if(ABC==3){ 
                    S3_FOUND=true;
                    if(i==0)S3_Mark=Parts[i];
                    if(i==1)S3_Lenght=Parts[i];
                    if(i==2)S3_Width=Parts[i];
                    if(i==3)S3_Height=Parts[i];
                    if(i==4)S3_Mass=Parts[i];
                    if(i==6)S3_Load=Parts[i];
                }
            //load data to object
            } 
        }
        private string createHead(){ 
            string head="";
                head+=sampleCode;
                head+=";";
                head+=sampleSimpleCode;
                head+=";";
                head+=sampleDate;
                head+="\n";
            return head;
        }
        private string zerolessFormat(){ 
            string formatData="";
            if(S1_FOUND){ 
                formatData+=S1_Mark;
                formatData+=";";
                formatData+=S1_Lenght;
                formatData+=";";
                formatData+=S1_Width;
                formatData+=";";
                formatData+=S1_Height;
                formatData+=";";
                formatData+=S1_Mass;
                formatData+=";";
                formatData+=S1_Load;
            }
            if(S2_FOUND){
                formatData+="\n";
                formatData+=S2_Mark;
                formatData+=";";
                formatData+=S2_Lenght;
                formatData+=";";
                formatData+=S2_Width;
                formatData+=";";
                formatData+=S2_Height;
                formatData+=";";
                formatData+=S2_Mass;
                formatData+=";";
                formatData+=S2_Load;
            }
            if(S3_FOUND){
                formatData+="\n";
                formatData+=S3_Mark;
                formatData+=";";
                formatData+=S3_Lenght;
                formatData+=";";
                formatData+=S3_Width;
                formatData+=";";
                formatData+=S3_Height;
                formatData+=";";
                formatData+=S3_Mass;
                formatData+=";";
                formatData+=S3_Load;
            }
            return formatData;
        }
        private string zeroFormat(){ 
            string formatData="";
                formatData+=S1_Mark;
                formatData+=";";
                formatData+=S1_Lenght;
                formatData+=";";
                formatData+=S1_Width;
                formatData+=";";
                formatData+=S1_Height;
                formatData+=";";
                formatData+=S1_Mass;
                formatData+=";";
                formatData+=S1_Load;
                formatData+="\n";
                formatData+=S2_Mark;
                formatData+=";";
                formatData+=S2_Lenght;
                formatData+=";";
                formatData+=S2_Width;
                formatData+=";";
                formatData+=S2_Height;
                formatData+=";";
                formatData+=S2_Mass;
                formatData+=";";
                formatData+=S2_Load;
                formatData+="\n";
                formatData+=S3_Mark;
                formatData+=";";
                formatData+=S3_Lenght;
                formatData+=";";
                formatData+=S3_Width;
                formatData+=";";
                formatData+=S3_Height;
                formatData+=";";
                formatData+=S3_Mass;
                formatData+=";";
                formatData+=S3_Load;
            return formatData;
        }

        public string getSampleAsFormatData(bool format)
        {
            string data="";
            data+=createHead();
            if(format) data+=zerolessFormat();
            else data+=zeroFormat();
            return data;
        }

        public bool haveData(){
            return (S1_FOUND|S2_FOUND|S3_FOUND);
        }
    }
}

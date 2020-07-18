using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class CubeSample : Sample
    {
        private const int dataArrLenght = 7;
        private enum DataTypeToName{ Mark=0, Mass=1, Lenght=2, Width=3, Height=4, Capacity=5, Load=6 };

        private bool S1_FOUND=false;
        private string[] S1_ArrData;

        private bool S2_FOUND=false;
        private string[] S2_ArrData;

        private bool S3_FOUND=false;
        private string[] S3_ArrData;

        public CubeSample(string code,string date){ 
            S1_ArrData=new string[dataArrLenght];
            S2_ArrData=new string[dataArrLenght];
            S3_ArrData=new string[dataArrLenght];
            ClearSample();

            getType=TypesEnums.Type.Cube; 
            sampleCode=code;
            sampleDate=date;
            sampleSimpleCode=cutSimpleCode();
        }

        protected override void ClearSample()
        {
            sampleCode="";
            sampleDate="";
            getType=TypesEnums.Type.NoType;

            S1_FOUND=S2_FOUND=S3_FOUND=false;
            for(int i=0;i<dataArrLenght;i++){ 
                S1_ArrData[i]="0";
                S2_ArrData[i]="0";
                S3_ArrData[i]="0";
            }
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
                    if(i==0)S1_ArrData[(int)DataTypeToName.Mark]=Parts[i];
                    if(i==1)S1_ArrData[(int)DataTypeToName.Lenght]=Parts[i];
                    if(i==2)S1_ArrData[(int)DataTypeToName.Width]=Parts[i];
                    if(i==3)S1_ArrData[(int)DataTypeToName.Height]=Parts[i];
                    if(i==4)S1_ArrData[(int)DataTypeToName.Mass]=Parts[i];
                    if(i==6)S1_ArrData[(int)DataTypeToName.Load]=Parts[i];
                }
                if(ABC==2){
                    S2_FOUND=true;
                    if(i==0)S2_ArrData[(int)DataTypeToName.Mark]=Parts[i];
                    if(i==1)S2_ArrData[(int)DataTypeToName.Lenght]=Parts[i];
                    if(i==2)S2_ArrData[(int)DataTypeToName.Width]=Parts[i];
                    if(i==3)S2_ArrData[(int)DataTypeToName.Height]=Parts[i];
                    if(i==4)S2_ArrData[(int)DataTypeToName.Mass]=Parts[i];
                    if(i==6)S2_ArrData[(int)DataTypeToName.Load]=Parts[i];                 
                }
                if(ABC==3){ 
                    S3_FOUND=true;
                    if(i==0)S3_ArrData[(int)DataTypeToName.Mark]=Parts[i];
                    if(i==1)S3_ArrData[(int)DataTypeToName.Lenght]=Parts[i];
                    if(i==2)S3_ArrData[(int)DataTypeToName.Width]=Parts[i];
                    if(i==3)S3_ArrData[(int)DataTypeToName.Height]=Parts[i];
                    if(i==4)S3_ArrData[(int)DataTypeToName.Mass]=Parts[i];
                    if(i==6)S3_ArrData[(int)DataTypeToName.Load]=Parts[i];
                }
            //load data to object
            } 
        }
        private void FillMassCapacityToSamples(){
            double tempResult=0;
            double temp_L_mm=0;
            double temp_W_mm=0;
            double temp_H_mm=0;
            if(S1_FOUND){
                try{
                    temp_L_mm=double.Parse(S1_ArrData[(int)DataTypeToName.Lenght],Processer.nfi);
                    temp_W_mm=double.Parse(S1_ArrData[(int)DataTypeToName.Width],Processer.nfi);
                    temp_H_mm=double.Parse(S1_ArrData[(int)DataTypeToName.Height],Processer.nfi);
                }catch (Exception e){ 
                    tempResult=0;
                    Processer.ConsoleBox.WriteToConsole(e.ToString()); 
                }
                 tempResult=this.calculateMassCapacity_dm3(temp_L_mm,temp_W_mm,temp_H_mm);
                 S1_ArrData[(int)DataTypeToName.Capacity] = tempResult.ToString();
            }
            if(S2_FOUND){
                try{
                    temp_L_mm=double.Parse(S2_ArrData[(int)DataTypeToName.Lenght],Processer.nfi);
                    temp_W_mm=double.Parse(S2_ArrData[(int)DataTypeToName.Width],Processer.nfi);
                    temp_H_mm=double.Parse(S2_ArrData[(int)DataTypeToName.Height],Processer.nfi);
                }catch (Exception e){ 
                    tempResult=0;
                    Processer.ConsoleBox.WriteToConsole(e.ToString()); 
                }
                 tempResult=this.calculateMassCapacity_dm3(temp_L_mm,temp_W_mm,temp_H_mm);
                 S2_ArrData[(int)DataTypeToName.Capacity] = tempResult.ToString();
            }  
            if(S3_FOUND){
                try{
                    temp_L_mm=double.Parse(S3_ArrData[(int)DataTypeToName.Lenght],Processer.nfi);
                    temp_W_mm=double.Parse(S3_ArrData[(int)DataTypeToName.Width],Processer.nfi);
                    temp_H_mm=double.Parse(S3_ArrData[(int)DataTypeToName.Height],Processer.nfi);
                }catch (Exception e){ 
                    tempResult=0;
                    Processer.ConsoleBox.WriteToConsole(e.ToString()); 
                }
                 tempResult=this.calculateMassCapacity_dm3(temp_L_mm,temp_W_mm,temp_H_mm);
                 S3_ArrData[(int)DataTypeToName.Capacity] = tempResult.ToString();
            }              
        }
        private double calculateMassCapacity_dm3(double L_mm, double W_mm, double H_mm){ 
            double result=0;
                result=(L_mm*W_mm*H_mm)/1000000;
                result=Math.Round(result,3);
            return result;
        }

        private string createHead(){ 
            string head="";
                head+=sampleCode;
                head+=";";
                head+=sampleSimpleCode;
                head+=";";
                head+=getType;
                head+=";";
                head+=sampleDate;
                head+="\n";
            return head;
        }
        private string createBody(){
            string formatData="";
                for(int i=0;i<dataArrLenght;i++){ 
                    formatData+=S1_ArrData[i];
                    formatData+=";";
                }
                formatData+="\n";
                for(int i=0;i<dataArrLenght;i++){ 
                    formatData+=S2_ArrData[i];
                    formatData+=";";
                }
                formatData+="\n";
                for(int i=0;i<dataArrLenght;i++){ 
                    formatData+=S3_ArrData[i];
                    formatData+=";";
                }      
            return formatData;
        }

        public override string getSampleAsFormatData()
        {
            FillMassCapacityToSamples();

            string data="";
            data+=createHead();
            data+=createBody();
            return data;
        }

        public override bool haveData(){
            return (S1_FOUND|S2_FOUND|S3_FOUND);
        }
    }
}

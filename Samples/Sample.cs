using System;
using System.Collections.Generic;

namespace ConcreteSampleTransformers
{
    public abstract class Sample
    {

        public TypesEnums.SampleType getType { get; set; }
        public string sampleCode{ get; set; }
        public string sampleDate { get; set; }

        public string sampleSimpleCode{ get { return cutSimpleCode(); } }

        protected int dataArrLenght = 0;

        //Maps
        protected Dictionary<int, int> FromToMap;

        protected bool S1_FOUND = false;
        protected string[] S1_ArrData;
        public ISamplePartDso S1_SampleDso;

        protected bool S2_FOUND = false;
        protected string[] S2_ArrData;
        public ISamplePartDso S2_SampleDso;

        protected bool S3_FOUND = false;
        protected string[] S3_ArrData;
        public ISamplePartDso S3_SampleDso;

        public abstract string getSampleAsFormatData();

        protected abstract void CreateDsoObjects();
        protected abstract void MapFromTo();

        protected virtual string FormatNumberString(string numbersString, char originalSeparator, char wantedSeparator)
        {
            string output = numbersString.Replace(originalSeparator, wantedSeparator);
            return output;
        }
        protected virtual void InitSample(){

            FromToMap = new Dictionary<int, int>();

            S1_FOUND = S2_FOUND = S3_FOUND = false;
            try
            {
                S1_ArrData = new string[dataArrLenght];
                S2_ArrData = new string[dataArrLenght];
                S3_ArrData = new string[dataArrLenght];
                S1_ArrData[0] = "";
                S2_ArrData[0] = "";
                S3_ArrData[0] = "";
                for (int i = 1; i < dataArrLenght; i++)
                {
                    S1_ArrData[i] = "0";
                    S2_ArrData[i] = "0";
                    S3_ArrData[i] = "0";
                }
            }
            catch (Exception e) { Processer.ConsoleBox.WriteLineToConsole("Error: " + e.Message + "|" + e.Source); }
            ClearSample();
            MapFromTo();
        }
        protected virtual void ClearSample()
        {
            sampleCode = "";
            sampleDate = "";
            getType = TypesEnums.SampleType.NoType;
        }

        public virtual bool haveData()
        {
            return (S1_FOUND | S2_FOUND | S3_FOUND);
        }

        protected string cutSimpleCode(){ 
            string simple="";
            int last_index=0;
            int first_index=0;
            try{
                last_index=sampleCode.LastIndexOf('/');
                first_index=sampleCode.IndexOf('/');
                simple=sampleCode.Substring(first_index+1,(last_index-first_index)-1);
            }
            catch (IndexOutOfRangeException e)
            {
                Processer.ConsoleBox.WriteLineToConsole(e.ToString());
                simple ="";
            }
            return simple;
        }

        protected virtual string createHead()
        {
            string head = "";
            head += sampleCode;
            head += ";";
            head += sampleSimpleCode;
            head += ";";
            head += getType;
            head += ";";
            head += sampleDate;
            //Add ; to create Table format CSV
            for (int i = 0; i < dataArrLenght-3; i++)
            {
                head += ";";
            }
            head += "\n";
            return head;
        }

        protected virtual string createBody()
        {
            string formatData = "";
            for (int i = 0; i < dataArrLenght; i++)
            {
                formatData += S1_ArrData[i];
                formatData += ";";
            }
            formatData += S1_FOUND.ToString();
            formatData += "\n";
            for (int i = 0; i < dataArrLenght; i++)
            {
                formatData += S2_ArrData[i];
                formatData += ";";
            }
            formatData += S2_FOUND.ToString();
            formatData += "\n";
            for (int i = 0; i < dataArrLenght; i++)
            {
                formatData += S3_ArrData[i];
                formatData += ";";
            }
            formatData += S3_FOUND.ToString();
            return formatData;
        }

        protected void TimeStampSample(){ 
            sampleDate=DateTime.Now.ToShortDateString();
        }
    }
}

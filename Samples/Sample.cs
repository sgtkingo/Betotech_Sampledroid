using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
        //Computed number formatted with output decimal separator (independent on OS culture)
        protected string FormatOutputNumber(decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture).Replace('.', PropertiesManager.outputNfiSeparator);
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
                //Code without "a/b/c" structure (e.g. 2602755) is already simple
                if (first_index < 0 || last_index <= first_index) return sampleCode;
                simple=sampleCode.Substring(first_index+1,(last_index-first_index)-1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Processer.ConsoleBox.WriteLineToConsole(e.ToString());
                simple ="";
            }
            return simple;
        }

        protected virtual string createHead()
        {
            var fields = new List<string> { sampleCode, sampleSimpleCode, getType.ToString(), sampleDate };
            //Pad with empty fields to create Table format CSV
            int rowLength = ProperitiesSamples.GetOutputRowLength(getType);
            while (fields.Count < rowLength) fields.Add(string.Empty);

            return string.Join(Processer.FieldSeparator.ToString(), fields) + "\n";
        }

        //One body row with columns selected in Settings
        private string createBodyRow(List<OutputColumn> columns, string[] arrData, bool found)
        {
            var fields = columns.Select(c => c.DataIndex == OutputColumn.ValidColumnIndex ? found.ToString() : arrData[c.DataIndex]).ToList();
            //Keep row as long as head row
            int rowLength = ProperitiesSamples.GetOutputRowLength(getType);
            while (fields.Count < rowLength) fields.Add(string.Empty);

            return string.Join(Processer.FieldSeparator.ToString(), fields);
        }

        protected virtual string createBody()
        {
            var columns = ProperitiesSamples.GetOutputColumns(getType);

            string formatData = "";
            formatData += createBodyRow(columns, S1_ArrData, S1_FOUND);
            formatData += "\n";
            formatData += createBodyRow(columns, S2_ArrData, S2_FOUND);
            formatData += "\n";
            formatData += createBodyRow(columns, S3_ArrData, S3_FOUND);
            return formatData;
        }

        protected void TimeStampSample(){ 
            sampleDate=DateTime.Now.ToShortDateString();
        }
    }
}

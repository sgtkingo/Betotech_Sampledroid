using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class CubeSample : Sample
    {
        private const int thisDataArrLenght = 8;
        public enum DataTypeToName{ ID=0, Hmotnost=1, Delka=2, Sirka=3, Vyska=4, Objem=5, ObjHmotnost=6, Tlak=7 };

        public CubeSample(string code,string date){
            dataArrLenght = thisDataArrLenght;
            InitSample();

            getType=TypesEnums.SampleType.Cube; 
            sampleCode=code;
            sampleDate=date;
        }

        public void FillSample(string data, int ABC){
            string formatData = FormatNumberString(data, PropertiesManager.inputNfiSeparator, PropertiesManager.outputNfiSeparator);
            string[] Parts=formatData.Split(';');
            for(int i=0;i<Parts.Length;i++){
                try
                {
                    if (ABC == 1)
                    {
                        S1_FOUND = true;
                        S1_ArrData[FromToMap[i]] = Parts[i];
                    }
                    if (ABC == 2)
                    {
                        S2_FOUND = true;
                        S2_ArrData[FromToMap[i]] = Parts[i];
                    }
                    if (ABC == 3)
                    {
                        S3_FOUND = true;
                        S3_ArrData[FromToMap[i]] = Parts[i];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exp: {ex.Message}|{ex.Source}, arg:[{i}]");
                }
            }
            CreateDsoObjects();
        }
        private void FillMassCapacityToSamples(){
            if(S1_SampleDso != null)
            {
                if (!S1_SampleDso.isValid()) return;

                 var S1_ObjectTmp = ((CubeSamplePartDso)S1_SampleDso);
                 S1_ArrData[(int)DataTypeToName.Objem] = S1_ObjectTmp.d_Objem.ToString();
            }
            if (S2_SampleDso != null)
            {
                if (!S2_SampleDso.isValid()) return;

                var S2_ObjectTmp = ((CubeSamplePartDso)S2_SampleDso);
                S2_ArrData[(int)DataTypeToName.Objem] = S2_ObjectTmp.d_Objem.ToString();
            }
            if (S3_SampleDso != null)
            {
                if (!S3_SampleDso.isValid()) return;

                var S3_ObjectTmp = ((CubeSamplePartDso)S3_SampleDso);
                S3_ArrData[(int)DataTypeToName.Objem] = S3_ObjectTmp.d_Objem.ToString();
            }
        }
        public override string getSampleAsFormatData()
        {
            FillMassCapacityToSamples();

            string data="";
            data+=createHead();
            data+=createBody();
            return data;
        }

        protected override void MapFromTo()
        {
            FromToMap.Clear();
            FromToMap.Add(0, (int)DataTypeToName.ID);
            FromToMap.Add(1, (int)DataTypeToName.Delka);
            FromToMap.Add(2, (int)DataTypeToName.Sirka);
            FromToMap.Add(3, (int)DataTypeToName.Vyska);
            FromToMap.Add(4, (int)DataTypeToName.Hmotnost);
            FromToMap.Add(5, (int)DataTypeToName.ObjHmotnost);
            FromToMap.Add(6, (int)DataTypeToName.Tlak);
        }


        protected override void CreateDsoObjects()
        {
            if (S1_FOUND) S1_SampleDso = new CubeSamplePartDso(S1_ArrData);
            if (S2_FOUND) S2_SampleDso = new CubeSamplePartDso(S2_ArrData);
            if (S3_FOUND) S3_SampleDso = new CubeSamplePartDso(S3_ArrData);
        }
    }
}

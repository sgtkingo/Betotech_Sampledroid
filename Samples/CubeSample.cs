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
        private const int thisDataArrLenght = 9;
        public enum DataTypeToName{ ID=0, Hmotnost=1, Delka=2, Sirka=3, Vyska=4, Objem=5, ObjHmotnost=6, Tlak=7, Pevnost=8 };

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
            FillComputedValues(S1_SampleDso as CubeSamplePartDso, S1_ArrData);
            FillComputedValues(S2_SampleDso as CubeSamplePartDso, S2_ArrData);
            FillComputedValues(S3_SampleDso as CubeSamplePartDso, S3_ArrData);
        }
        private void FillComputedValues(CubeSamplePartDso dso, string[] arrData)
        {
            if (dso == null || !dso.isValid()) return;

            arrData[(int)DataTypeToName.Objem] = FormatOutputNumber(dso.d_Objem);

            //Volumetric density is missing (0) in input, computed from weight and volume
            if (dso.d_ObjHmotnost == 0 && dso.d_Vaha > 0 && dso.d_Objem > 0)
            {
                arrData[(int)DataTypeToName.ObjHmotnost] = FormatDensity(dso.d_Vaha, dso.d_Objem);
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
            FromToMap.Add(7, (int)DataTypeToName.Pevnost);
        }


        protected override void CreateDsoObjects()
        {
            if (S1_FOUND) S1_SampleDso = new CubeSamplePartDso(S1_ArrData);
            if (S2_FOUND) S2_SampleDso = new CubeSamplePartDso(S2_ArrData);
            if (S3_FOUND) S3_SampleDso = new CubeSamplePartDso(S3_ArrData);
        }
    }
}

using System;

namespace ConcreteSampleTransformers
{
    public class CylinderSample : Sample
    {
        private const int thisDataArrLenght = 8;
        public enum DataTypeToName { ID = 0, Prumer = 1, Vyska = 2, Objem = 3, ObjHmotnost = 4, Tlak = 5, Hmotnost = 6, Pevnost = 7 }

        public CylinderSample(string code, string date)
        {
            dataArrLenght = thisDataArrLenght;
            InitSample();

            getType = TypesEnums.SampleType.Cylinder;
            sampleCode = code;
            sampleDate = date;
        }

        public void FillSample(string data, int ABC)
        {
            string formatData = FormatNumberString(data, PropertiesManager.inputNfiSeparator, PropertiesManager.outputNfiSeparator);
            string[] Parts = formatData.Split(';');
            for (int i = 0; i < Parts.Length; i++)
            {
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
        private void FillMassCapacityToSamples()
        {
            FillComputedValues(S1_SampleDso as CylinderSamplePartDso, S1_ArrData);
            FillComputedValues(S2_SampleDso as CylinderSamplePartDso, S2_ArrData);
            FillComputedValues(S3_SampleDso as CylinderSamplePartDso, S3_ArrData);
        }
        private void FillComputedValues(CylinderSamplePartDso dso, string[] arrData)
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

            string data = "";
            data += createHead();
            data += createBody();
            return data;
        }

        protected override void MapFromTo()
        {
            FromToMap.Clear();
            FromToMap.Add(0, (int)DataTypeToName.ID);
            FromToMap.Add(1, (int)DataTypeToName.Prumer);
            FromToMap.Add(2, (int)DataTypeToName.Vyska);
            //Input layout by analogy with cube: ID; diameter; height; weight; density; force; strength
            FromToMap.Add(3, (int)DataTypeToName.Hmotnost);
            FromToMap.Add(4, (int)DataTypeToName.ObjHmotnost);
            FromToMap.Add(5, (int)DataTypeToName.Tlak);
            FromToMap.Add(6, (int)DataTypeToName.Pevnost);
        }


        protected override void CreateDsoObjects()
        {
            if (S1_FOUND) S1_SampleDso = new CylinderSamplePartDso(S1_ArrData);
            if (S2_FOUND) S2_SampleDso = new CylinderSamplePartDso(S2_ArrData);
            if (S3_FOUND) S3_SampleDso = new CylinderSamplePartDso(S3_ArrData);
        }
    }
}

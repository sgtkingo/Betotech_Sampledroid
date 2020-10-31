using System;

namespace ConcreteSampleTransformers
{
    public class CylinderSample : Sample
    {
        private const int thisDataArrLenght = 6;
        public enum DataTypeToName { ID = 0, Prumer = 1, Vyska = 2, Objem = 3, ObjHmotnost = 4, Tlak = 5 }

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
            if (S1_SampleDso != null)
            {
                if (!S1_SampleDso.isValid()) return;

                var S1_ObjectTmp = ((CylinderSamplePartDso)S1_SampleDso);
                S1_ArrData[(int)DataTypeToName.Objem] = S1_ObjectTmp.d_Objem.ToString();
            }
            if (S2_SampleDso != null)
            {
                if (!S2_SampleDso.isValid()) return;

                var S2_ObjectTmp = ((CylinderSamplePartDso)S2_SampleDso);
                S2_ArrData[(int)DataTypeToName.Objem] = S2_ObjectTmp.d_Objem.ToString();
            }
            if (S3_SampleDso != null)
            {
                if (!S3_SampleDso.isValid()) return;

                var S3_ObjectTmp = ((CylinderSamplePartDso)S3_SampleDso);
                S3_ArrData[(int)DataTypeToName.Objem] = S3_ObjectTmp.d_Objem.ToString();
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
            FromToMap.Add(4, (int)DataTypeToName.ObjHmotnost);
            FromToMap.Add(5, (int)DataTypeToName.Tlak);
        }


        protected override void CreateDsoObjects()
        {
            if (S1_FOUND) S1_SampleDso = new CylinderSamplePartDso(S1_ArrData);
            if (S2_FOUND) S2_SampleDso = new CylinderSamplePartDso(S2_ArrData);
            if (S3_FOUND) S3_SampleDso = new CylinderSamplePartDso(S3_ArrData);
        }
    }
}

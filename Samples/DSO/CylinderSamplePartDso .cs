using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    class CylinderSamplePartDso : ISamplePartDso
    {
        public string s_ID { get; set; } //Sekundární identifikator vzorku
        public decimal d_Prumer { get; set; } //Delka [mm]
        public decimal d_Vyska { get; set; } //Výška [mm]
        public decimal d_Objem { get; set; } //Objem [dm^3]
        public decimal d_ObjHmotnost { get; set; } //Obj. hmotnost [kg/m^3]
        public decimal d_Tlak { get; set; } //Tlak [kN]

        public CylinderSamplePartDso(string[] data)
        {
            valid = FillMe(data);
            CalculateCapacity();
        }

        private void CalculateCapacity(){
            if (!valid) return;

            decimal tempResult = 0;
            decimal baseResult = 0;

            //V = pi * (d/2)^2 * h, [mm^3] -> [dm^3]
            baseResult = ((decimal)Math.PI * d_Prumer * d_Prumer) / 4;
            tempResult = (baseResult*d_Vyska) / 1000000;
            tempResult = Math.Round(tempResult, 3);

            d_Objem = tempResult;
        }
        public override bool FillMe(string[] data) {
            if (data.Length == 0) return false;
            try
            {
                s_ID = (string)Convert.ChangeType(data[(int)CylinderSample.DataTypeToName.ID], typeof(string));
                d_Vyska = (decimal)Convert.ChangeType(data[(int)CylinderSample.DataTypeToName.Vyska], typeof(decimal));
                d_Prumer = (decimal)Convert.ChangeType(data[(int)CylinderSample.DataTypeToName.Prumer], typeof(decimal));
                d_Objem = (decimal)Convert.ChangeType(data[(int)CylinderSample.DataTypeToName.Objem], typeof(decimal));
                d_ObjHmotnost = (decimal)Convert.ChangeType(data[(int)CylinderSample.DataTypeToName.ObjHmotnost], typeof(decimal));
                d_Tlak = (decimal)Convert.ChangeType(data[(int)CylinderSample.DataTypeToName.Tlak], typeof(decimal));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: {ex.Message}|{ex.Source}");
                return false;
            }
            return true;
        }
    }
}

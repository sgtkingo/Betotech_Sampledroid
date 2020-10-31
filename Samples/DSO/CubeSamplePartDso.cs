using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    class CubeSamplePartDso : ISamplePartDso
    {
        public string s_ID { get; set; } //Sekundární identifikator vzorku
        public decimal d_Vaha { get; set; } //Váha [kg]
        public decimal d_Delka { get; set; } //Delka [mm]
        public decimal d_Sirka { get; set; } //Sirka [mm]
        public decimal d_Vyska { get; set; } //Výška [mm]
        public decimal d_Objem { get; set; } //Objem [dm^3]
        public decimal d_ObjHmotnost { get; set; } //Obj. hmotnost [kg/m^3]
        public decimal d_Tlak { get; set; } //Tlak [kN]

        public CubeSamplePartDso(string[] data)
        {
            valid = FillMe(data);
            CalculateCapacity();
        }

        private void CalculateCapacity(){
            if (!valid) return;

            decimal tempResult = 0;
            tempResult = (d_Delka * d_Sirka * d_Vyska) / 1000000;
            tempResult = Math.Round(tempResult, 3);

            d_Objem = tempResult;
        }
        public override bool FillMe(string[] data) {
            if (data.Length == 0) return false;
            try
            {
                s_ID = (string)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.ID], typeof(string));
                d_Vaha = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.Hmotnost], typeof(decimal));
                d_Delka = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.Delka], typeof(decimal));
                d_Sirka = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.Sirka], typeof(decimal));
                d_Vyska = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.Vyska], typeof(decimal));
                d_Objem = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.Objem], typeof(decimal));
                d_ObjHmotnost = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.ObjHmotnost], typeof(decimal));
                d_Tlak = (decimal)Convert.ChangeType(data[(int)CubeSample.DataTypeToName.Tlak], typeof(decimal));
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

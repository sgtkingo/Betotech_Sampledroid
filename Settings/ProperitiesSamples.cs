using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class ProperitiesSamples
    {
        //Sample properities
        private static string CubeHeadLabels = $"Kod [-];Vaha [kg];Delka [mm];Sirka [mm];Vyska [mm];Objem [dm^3];Obj. hmotnost [kg/m^3];Tlak [kN];Valid [True/False]\n";
        private static string CylinderHeadLabels = $"Kod [-];Prumer [mm];Vyska [mm];Objem [dm^3];Obj. hmotnost [kg/m^3];Tlak [kN];Valid [True/False]\n";
        private const string CubeFileExtensionName = "_Cube";
        private const string CylinderFileExtensionName = "_Cylinder";

        private static Dictionary<TypesEnums.SampleType, string> sampleExtensionNameMap = new Dictionary<TypesEnums.SampleType, string>();
        private static Dictionary<TypesEnums.SampleType, string> sampleLabelsMap = new Dictionary<TypesEnums.SampleType, string>();
        public static void MapSamplesLabels()
        {
            sampleLabelsMap.Clear();
            sampleLabelsMap.Add(TypesEnums.SampleType.Cube, CubeHeadLabels);
            sampleLabelsMap.Add(TypesEnums.SampleType.Cylinder, CylinderHeadLabels);

            sampleExtensionNameMap.Clear();
            sampleExtensionNameMap.Add(TypesEnums.SampleType.Cube, CubeFileExtensionName);
            sampleExtensionNameMap.Add(TypesEnums.SampleType.Cylinder, CylinderFileExtensionName);
        }

        public static string GetSampleLabelByType(TypesEnums.SampleType sampleType){
            return sampleLabelsMap[sampleType];
        }
        public static string GetSampleExtensionNameByType(TypesEnums.SampleType sampleType)
        {
            return sampleExtensionNameMap[sampleType];
        }
        public static string GetDateTimeStamp(){
            return $"DATE / TIME:{ DateTime.Now.ToShortDateString()}|{ DateTime.Now.ToShortTimeString()}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    //One column of the output file / data view
    public class OutputColumn
    {
        public const int ValidColumnIndex = -1;

        public string Key { get; private set; }     //Stable identifier stored in settings
        public string Label { get; private set; }   //Column header in output
        public int DataIndex { get; private set; }  //Index into sample data array, ValidColumnIndex = Valid flag

        public OutputColumn(string key, string label, int dataIndex)
        {
            Key = key;
            Label = label;
            DataIndex = dataIndex;
        }

        public override string ToString()
        {
            return Label;
        }
    }

    public static class ProperitiesSamples
    {
        //Sample properities
        private const string CubeFileExtensionName = "_Cube";
        private const string CylinderFileExtensionName = "_Cylinder";
        private const char ColumnConfigSeparator = ',';
        //Head row (code; simple code; type; date) needs at least this number of columns
        private const int HeadColumnsCount = 4;

        private static Dictionary<TypesEnums.SampleType, string> sampleExtensionNameMap = new Dictionary<TypesEnums.SampleType, string>();
        private static Dictionary<TypesEnums.SampleType, List<OutputColumn>> columnCatalogMap = new Dictionary<TypesEnums.SampleType, List<OutputColumn>>();

        public static void MapSamplesLabels()
        {
            columnCatalogMap.Clear();
            columnCatalogMap.Add(TypesEnums.SampleType.Cube, new List<OutputColumn> {
                new OutputColumn("ID", "Kod [-]", (int)CubeSample.DataTypeToName.ID),
                new OutputColumn("Hmotnost", "Vaha [kg]", (int)CubeSample.DataTypeToName.Hmotnost),
                new OutputColumn("Delka", "Delka [mm]", (int)CubeSample.DataTypeToName.Delka),
                new OutputColumn("Sirka", "Sirka [mm]", (int)CubeSample.DataTypeToName.Sirka),
                new OutputColumn("Vyska", "Vyska [mm]", (int)CubeSample.DataTypeToName.Vyska),
                new OutputColumn("Objem", "Objem [dm^3]", (int)CubeSample.DataTypeToName.Objem),
                new OutputColumn("ObjHmotnost", "Obj. hmotnost [kg/m^3]", (int)CubeSample.DataTypeToName.ObjHmotnost),
                new OutputColumn("Tlak", "Tlak [kN]", (int)CubeSample.DataTypeToName.Tlak),
                new OutputColumn("Pevnost", "Pevnost [MPa]", (int)CubeSample.DataTypeToName.Pevnost),
                new OutputColumn("Valid", "Valid [True/False]", OutputColumn.ValidColumnIndex),
            });
            columnCatalogMap.Add(TypesEnums.SampleType.Cylinder, new List<OutputColumn> {
                new OutputColumn("ID", "Kod [-]", (int)CylinderSample.DataTypeToName.ID),
                new OutputColumn("Hmotnost", "Vaha [kg]", (int)CylinderSample.DataTypeToName.Hmotnost),
                new OutputColumn("Prumer", "Prumer [mm]", (int)CylinderSample.DataTypeToName.Prumer),
                new OutputColumn("Vyska", "Vyska [mm]", (int)CylinderSample.DataTypeToName.Vyska),
                new OutputColumn("Objem", "Objem [dm^3]", (int)CylinderSample.DataTypeToName.Objem),
                new OutputColumn("ObjHmotnost", "Obj. hmotnost [kg/m^3]", (int)CylinderSample.DataTypeToName.ObjHmotnost),
                new OutputColumn("Tlak", "Tlak [kN]", (int)CylinderSample.DataTypeToName.Tlak),
                new OutputColumn("Pevnost", "Pevnost [MPa]", (int)CylinderSample.DataTypeToName.Pevnost),
                new OutputColumn("Valid", "Valid [True/False]", OutputColumn.ValidColumnIndex),
            });

            sampleExtensionNameMap.Clear();
            sampleExtensionNameMap.Add(TypesEnums.SampleType.Cube, CubeFileExtensionName);
            sampleExtensionNameMap.Add(TypesEnums.SampleType.Cylinder, CylinderFileExtensionName);
        }

        //All columns available for sample type, in default order
        public static List<OutputColumn> GetColumnCatalog(TypesEnums.SampleType sampleType)
        {
            return columnCatalogMap[sampleType];
        }

        //Selected columns in configured order; empty/invalid config = all columns
        public static List<OutputColumn> ParseColumnConfig(TypesEnums.SampleType sampleType, string config)
        {
            var catalog = GetColumnCatalog(sampleType);
            var selected = new List<OutputColumn>();

            if (!string.IsNullOrWhiteSpace(config))
            {
                foreach (string key in config.Split(ColumnConfigSeparator))
                {
                    var column = catalog.FirstOrDefault(c => c.Key == key.Trim());
                    if (column != null && !selected.Contains(column)) selected.Add(column);
                }
            }
            return selected.Count > 0 ? selected : new List<OutputColumn>(catalog);
        }

        public static string BuildColumnConfig(IEnumerable<OutputColumn> columns)
        {
            return string.Join(ColumnConfigSeparator.ToString(), columns.Select(c => c.Key));
        }

        //Columns used for output by current settings
        public static List<OutputColumn> GetOutputColumns(TypesEnums.SampleType sampleType)
        {
            return ParseColumnConfig(sampleType, PropertiesManager.GetOutputColumnsConfig(sampleType));
        }

        //Number of fields in every output row (head row needs at least HeadColumnsCount)
        public static int GetOutputRowLength(TypesEnums.SampleType sampleType)
        {
            return Math.Max(HeadColumnsCount, GetOutputColumns(sampleType).Count);
        }

        public static string GetSampleLabelByType(TypesEnums.SampleType sampleType){
            var labels = GetOutputColumns(sampleType).Select(c => c.Label).ToList();
            //Pad labels so head row (code; simple code; type; date) always fits
            while (labels.Count < HeadColumnsCount) labels.Add(string.Empty);
            return string.Join(Processer.FieldSeparator.ToString(), labels) + "\n";
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

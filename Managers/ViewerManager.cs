using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers.Managers
{
    public class ViewerManager
    {
        Storage _Storage;

        public ViewerManager(Storage storage){
            _Storage = storage;       
        }

        public DataView GenerateTableViewByType(TypesEnums.SampleType sampleType)
        {
            DataTable DataTable = new DataTable(sampleType.ToString());
            DataView DataView = null;

            string DATA = string.Empty;
            string LABELS = ProperitiesSamples.GetSampleLabelByType(sampleType);

            try
            {
                var columns = CreateCollumsFromLabels(LABELS.Split(';'));
                DataTable.Columns.AddRange(columns);

                foreach (Sample S in _Storage.GetFiltredSamples(sampleType))
                {
                    DATA = S.getSampleAsFormatData();
                    var stringRows = DATA.Split('\n');
                    foreach (string stringRow in stringRows)
                    {
                        var row = DataTable.NewRow();
                        var stringArray = stringRow.Split(';');
                        for (int i = 0; i < stringArray.Length; i++)
                        {
                            row[i] = stringArray[i];
                        }
                        DataTable.Rows.Add(row);
                    }

                }
                DataView = new DataView(DataTable);
            }
            catch (Exception e)
            {
               Console.WriteLine($"PROBLEM: {e.Message} | {e.Source} ");
            }
            return DataView;
        }

        private DataColumn[] CreateCollumsFromLabels(string[] labes){
            DataColumn[] dataColumns = new DataColumn[labes.Length];

            for (int i = 0; i < labes.Length; i++)
            {
                var collum = new DataColumn(labes[i]);
                dataColumns[i] = collum;
            }

            return dataColumns;
        }
    }
}

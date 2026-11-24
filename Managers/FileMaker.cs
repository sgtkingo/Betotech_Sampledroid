using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcreteSampleTransformers.Managers;

using ControlModul.FileControl;

namespace ConcreteSampleTransformers
{
    public class FileMaker
    {
        Storage Storage;
        DataManager DatabaseManager;

        public FileMaker(Storage storage, DataManager databaseManager) {
            Storage = storage;
            DatabaseManager = databaseManager;
        }

        public bool MakeFiles(TypesEnums.FileType T) {
            if (T == TypesEnums.FileType.CSV) return MakeCSVFiles();
            if (T == TypesEnums.FileType.DATABASE) return MakeDabaseTransaction();
            if (T == TypesEnums.FileType.ALL) return (MakeCSVFiles() && MakeDabaseTransaction());

            return false;
        }

        //TODO
        private bool MakeDabaseTransaction(){
            var samples = PrepareDataForDatabase();
            return DatabaseManager.SaveData(samples);
        }

        //TODO Generate list of samples
        private List<object> PrepareDataForDatabase(){
            return null;
        }

        private bool MakeCSVFiles() {
            if (!PropertiesManager.IsValidDirectory(PropertiesManager.outputDataPath))
            {
                Processer.ConsoleBox.Error("Output folder not set - see Settings");
                return false;
            }
            return
                (SaveSamplesByTypeAsCSV(TypesEnums.SampleType.Cube)
                & SaveSamplesByTypeAsCSV(TypesEnums.SampleType.Cylinder));
        }

        private bool SaveSamplesByTypeAsCSV(TypesEnums.SampleType sampleType)
        {
            if (Storage.isListEmpty(sampleType)) return true;

            string FP = PropertiesManager.GetSampleFilePathByType(sampleType);
            string fileName = Path.GetFileName(FP);

            //Samples are formatted with internal separator ';', output file uses the one chosen in Settings
            char outputSeparator = PropertiesManager.outputFieldSeparator;

            var content = new StringBuilder();
            content.Append(ProperitiesSamples.GetSampleLabelByType(sampleType).Replace(Processer.FieldSeparator, outputSeparator));
            foreach (Sample S in Storage.GetFiltredSamples(sampleType))
            {
                content.Append(S.getSampleAsFormatData().Replace(Processer.FieldSeparator, outputSeparator));
                content.Append("\n");
            }
            content.Append(ProperitiesSamples.GetDateTimeStamp());

            //Written directly: ControlModul FileManager reports success even when writing fails
            try
            {
                File.WriteAllText(FP, content.ToString());
            }
            catch (Exception e)
            {
                Processer.ConsoleBox.Error($"Cannot save {fileName}: {e.Message.Trim()}");
                return false;
            }
            Processer.ConsoleBox.Detail($"→ {fileName}");
            return true;
        }
    }
}

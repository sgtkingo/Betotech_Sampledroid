using System;
using System.Collections.Generic;
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
            return 
                (SaveSamplesByTypeAsCSV(TypesEnums.SampleType.Cube)
                & SaveSamplesByTypeAsCSV(TypesEnums.SampleType.Cylinder));
        }

        private bool SaveSamplesByTypeAsCSV(TypesEnums.SampleType sampleType)
        {
            if (Storage.isListEmpty(sampleType)) return true;

            VirtualFile virtualFile = new VirtualFile();
            string DATA = "";
            string FP = PropertiesManager.GetSampleFilePathByType(sampleType);
            string LABELS = ProperitiesSamples.GetSampleLabelByType(sampleType);

            //Samples are formatted with internal separator ';', output file uses the one chosen in Settings
            char outputSeparator = PropertiesManager.outputFieldSeparator;

            virtualFile.AppendFile(FP);
            virtualFile.SetLabels(LABELS.Replace(Processer.FieldSeparator, outputSeparator));
            foreach (Sample S in Storage.GetFiltredSamples(sampleType))
            {
                DATA += S.getSampleAsFormatData().Replace(Processer.FieldSeparator, outputSeparator);
                DATA += "\n";
            }
            DATA += ProperitiesSamples.GetDateTimeStamp();

            virtualFile.FillFile(DATA);
            return FileManager.SaveFile(virtualFile);
        }
    }
}

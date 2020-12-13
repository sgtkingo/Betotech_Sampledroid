using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcreteSampleTransformers.Managers;

namespace ConcreteSampleTransformers
{
    public class FileMaker
    {
        Storage Storage;
        DatabaseManager DatabaseManager;

        public FileMaker(Storage storage, DatabaseManager databaseManager) {
            Storage = storage;
            DatabaseManager = databaseManager;
        }

        public bool MakeFiles(TypesEnums.FileType T) {
            if (T == TypesEnums.FileType.CSV) return MakeCSVFiles();
            if (T == TypesEnums.FileType.DATABASE) return MakeDabaseTransaction();
            return false;
        }

        private bool MakeDabaseTransaction(){
            return DatabaseManager.SaveDataToDatabase();
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

            virtualFile.appendFile(FP);
            virtualFile.setLabels(LABELS);
            foreach (Sample S in Storage.GetFiltredSamples(sampleType))
            {
                DATA += S.getSampleAsFormatData();
                DATA += "\n";
            }
            DATA += ProperitiesSamples.GetDateTimeStamp();

            virtualFile.fillFile(DATA);
            return FileManager.SaveFile(virtualFile);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class FileMaker
    {
        Storage Storage;

        public static bool MakeFileProcedureOK { get; private set; }

        public FileMaker(Storage storage) {
            Storage = storage;
        }

        public bool MakeFiles(TypesEnums.FileType T) {
            if (T == TypesEnums.FileType.CSV) return MakeCSVFiles();
            if (T == TypesEnums.FileType.OBJECT) return MakeObjectFiles();
            return false;
        }
        private bool MakeObjectFiles()
        {
            //Dodelat
            return false;
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

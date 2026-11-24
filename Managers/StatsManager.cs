using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class StatsManager
    {
        Storage _Storage;
        ConsoleBox _ConsoleBox;

        public StatsManager(Storage storage, ConsoleBox consoleBox){
            _Storage = storage;
            _ConsoleBox = consoleBox;
        }

        public void GenerateStats(){
            _ConsoleBox.Info($"Samples : {_Storage.GetNumberOfSamples(),4}");
            _ConsoleBox.Detail($"Cube    : {_Storage.GetNumberOfSamplesByType(TypesEnums.SampleType.Cube),4}");
            _ConsoleBox.Detail($"Cylinder: {_Storage.GetNumberOfSamplesByType(TypesEnums.SampleType.Cylinder),4}");
        }
    }
}

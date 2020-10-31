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
            string stats = string.Empty;

            _ConsoleBox.WriteLineToConsole("\t***STATS***", ConsoleBox.LineType.Bold);
            stats = $"Total generated samples: -{_Storage.GetNumberOfSamples()}-";
            _ConsoleBox.WriteLineToConsole(stats);

            stats = $"Generated -{_Storage.GetNumberOfSamplesByType(TypesEnums.SampleType.Cube)}- {TypesEnums.SampleType.Cube} samples \n";
            stats += $"Generated -{_Storage.GetNumberOfSamplesByType(TypesEnums.SampleType.Cylinder)}- {TypesEnums.SampleType.Cylinder} samples \n";
            _ConsoleBox.WriteLineToConsole(stats, ConsoleBox.LineType.Bold);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class PrototypeSample : Sample

    {
        public int getType { get; set; }
        public string sampleCode { get; set; }
        public string sampleSimpleCode { get; set; }

        public PrototypeSample(string code){
            getType=(int)TypesEnums.Type.NoType;
            sampleCode=code;
        }

        public string getSampleAsFormatData(bool format)
        {
            return "";
        }

        public bool haveData()
        {
            return false;
        }
    }
}

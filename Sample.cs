using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public interface Sample
    {
        int getType{ get;set; }
        string sampleCode{ get; set; }
        string sampleSimpleCode{ get; set; }

        string getSampleAsFormatData(bool format);  
        bool haveData();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public abstract class Sample
    {
        public TypesEnums.Type getType{ get; set; }
        public string sampleCode{ get; set; }
        public string sampleSimpleCode{ get; set; }
        public string sampleDate { get; set; }

        protected abstract void ClearSample(); 
        public abstract string getSampleAsFormatData();  
        public abstract bool haveData();

        protected string cutSimpleCode(){ 
            string simple="";
            int last_index=0;
            int first_index=0;
            try{
                last_index=sampleCode.LastIndexOf('/');
                first_index=sampleCode.IndexOf('/');
                simple=sampleCode.Substring(first_index+1,(last_index-first_index)-1);
            }catch(IndexOutOfRangeException e){ Processer.ConsoleBox.WriteLineToConsole(e.ToString()); simple=""; }
            return simple;
        }

        protected void TimeStampSample(){ 
            sampleDate=DateTime.Now.ToShortDateString();
        }
    }
}

using System;

namespace ConcreteSampleTransformers
{
    public class PrototypeSample : Sample

    {
        public PrototypeSample(string code){
            getType=TypesEnums.Type.NoType;
            sampleCode=code;
            TimeStampSample();
        }

        public override string getSampleAsFormatData()
        {
            return "";
        }

        public override bool haveData()
        {
            return false;
        }

        protected override void ClearSample()
        {
            sampleCode="";
            sampleDate="";
            getType=TypesEnums.Type.NoType;
        }
    }
}

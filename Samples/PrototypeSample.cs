using System;

namespace ConcreteSampleTransformers
{
    public class PrototypeSample : Sample

    {
        public PrototypeSample(string code){
            getType=TypesEnums.SampleType.NoType;
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
            getType=TypesEnums.SampleType.NoType;
        }

        protected override void CreateDsoObjects()
        {
            throw new NotImplementedException();
        }

        protected override void MapFromTo()
        {
            return;
        }
    }
}

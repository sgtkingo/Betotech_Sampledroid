using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public abstract class ISamplePartDso
    {
        protected bool valid = false;

        public bool isValid()
        {
            return valid;
        }
        public abstract bool FillMe(string[] data);
    }
}

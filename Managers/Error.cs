using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteSampleTransformers
{
    public class Error
    {
        public string ErrorType{ get;set; }
        public string ErrorID{ get;set; }
        public string ErrorInfo{ get;set; }

        public Error(string type, string info, string id){
            ErrorType=type;
            ErrorInfo=info;
            ErrorID=id;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(ErrorID) ? ErrorInfo : $"{ErrorID}: {ErrorInfo}";
        }
    }
}

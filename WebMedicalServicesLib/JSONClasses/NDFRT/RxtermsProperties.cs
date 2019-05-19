using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMedicalServicesLib.JSONClasses.NDFRT
{
    public class RxtermsProperties
    {
        public string brandName { get; set; }
        public string displayName { get; set; }
        public string synonym { get; set; }
        public string fullName { get; set; }
        public string fullGenericName { get; set; }
        public string strength { get; set; }
        public string rxtermsDoseForm { get; set; }
        public string route { get; set; }
        public string termType { get; set; }
        public string rxcui { get; set; }
        public string genericRxcui { get; set; }
        public string rxnormDoseForm { get; set; }
        public string suppress { get; set; }
    }

}

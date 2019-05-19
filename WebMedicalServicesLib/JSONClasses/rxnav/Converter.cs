using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMedicalServicesLib.JSONClasses.rxnav
{
    public class IdGroup
    {
        public string idType { get; set; }
        public string id { get; set; }
        public List<string> rxnormId { get; set; }
    }

    public class Converter
    {
        public IdGroup idGroup { get; set; }
    }
}

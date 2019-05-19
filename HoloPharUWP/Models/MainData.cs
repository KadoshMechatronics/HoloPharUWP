using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloPharUWP.Models
{
    class MainData: ObservableCollection<string>
    {
        public MainData() : base()
        {

        }

        public ObservableCollection<string> DrugNames { get; set; }
    }
}

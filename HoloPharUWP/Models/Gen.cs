using DataContainer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloPharUWP.Models
{
  public static  class Gen
    {
        private static ObservableCollection<string> drugNames=new ObservableCollection<string>();
        public static ObservableCollection<string> DrugNames { get
            {
                return drugNames;
            }
            set
            {
                drugNames = value;
            }
        }

        public static User CurrentUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloPharUWP.Models
{

  public  class Menu
    {
        public ObservableCollection<TopMenu> TopMenuItems { get; set; }
        public Menu()
        {
            TopMenuItems = new ObservableCollection<TopMenu>();
        }
    }

    public class TopMenu
    {
        public string GroupName { get; set; }
        public ObservableCollection<SubMenu> SubMenuItems { get; set; }
        public TopMenu()
        {
            SubMenuItems = new ObservableCollection<SubMenu>();
        }
    }

    public class SubMenu
    {
        public string ItemName { get; set; }
    }

}

using HoloPharUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HoloPharUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrugInteractions : Page
    {
        public DrugInteractions()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string dose = @"cyclosporine;

    lithium;

    methotrexate;

    rifampin;

    antifungal medicine;

    a blood thinner (warfarin, Coumadin, Jantoven);

    heart or blood pressure medication;

    other forms of diclofenac(Flector, Pennsaid, Solaraze, Voltaren Gel);

            other NSAIDs -aspirin, ibuprofen(Advil, Motrin), naproxen(Aleve), celecoxib(Celebrex), indomethacin, meloxicam, and others; or

        steroid medicine(prednisone and others).
";


            txtSide.Text = dose;

        }
        //    private async void Page_Loaded(object sender, RoutedEventArgs e)
        //    {
        ////        Models.Menu m = new Models.Menu();
        ////        List<Tuple<string, List<string>>> li = new List<Tuple<string, List<string>>>();

        ////        WebMedicalServicesLib.Main main = new WebMedicalServicesLib.Main();
        ////        Menu menu = new Menu();

        ////        if(Gen.DrugNames !=null)
        ////        {
        ////foreach (var item in Models.Gen.DrugNames)
        ////        {
        ////            var c = await main.DrugDoseAsync(item);
        ////            menu.TopMenuItems.Add(new TopMenu() { GroupName = item });


        ////            menu.TopMenuItems[0].SubMenuItems=c;

        ////        }
        ////        this.DataContext = menu;
        ////        }



        //    }


        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //TextBlock txtBlock = ((Windows.UI.Xaml.RoutedEventArgs)(e)).OriginalSource as TextBlock;
            //if (txtBlock != null)
            //{
            //    txtSubMenuTapped.Text = txtSubMenuTapped.Tag.ToString() + txtBlock.Text;
            //}
            //e.Handled = true;
        }

    }
}

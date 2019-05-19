using System;
using System.Collections.Generic;
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
    public sealed partial class DirectionsView : Page
    {
        public DirectionsView()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string dose = @"Parenteral:
Weight 50 kg or greater: 1000 mg IV every 6 hours OR 650 mg IV every 4 hours
Maximum Single Dose: 1000 mg
Minimum Dosing Interval: every 4 hours
Maximum Dose: 4000 mg per 24 hours

Weight less than 50 kg: 15 mg / kg IV every 6 hours OR 12.5 mg / kg IV every 4 hours
    Maximum Single Dose: 15 mg / kg
Minimum Dosing Interval: every 4 hours
Maximum Dose: 75 mg / kg per 24 hours

  Oral:
Immediate - release: 325 mg to 1 g orally every 4 to 6 hours
  Minimum Dosing Interval: every 4 hours
  Maximum Single Dose: 1000 mg
  Maximum Dose: 4 g per 24 hours

Extended - Release: 1300 mg orally every 8 hours
  Maximum dose: 3900 mg per 24 hours

  Rectal:
650 mg rectally every 4 to 6 hours
Maximum dose: 3900 mg per 24 hours
";
            string direction = @"-For the management of mild to moderate pain and the management of moderate to severe pain with adjunctive opioid analgesics.
-For the reduction of fever.

Usual Pediatric Dose for Fever:

PARENTERAL:
2 to 12 years: 15 mg/kg IV or 12.5 mg/kg IV every 4 hours
Maximum Single Dose: 15 mg/kg; not to exceed 750 mg
Minimum Dosing Interval: every 4 hours
Maximum Daily Dose: 75 mg/kg in 24 hours; not to exceed 3750 mg

13 years or older; weight less than 50 kg: 15 mg/kg IV every 6 hours OR 12.5 mg/kg IV every 4 hours
Maximum Single Dose: 15 mg/kg
Minimum Dosing Interval: every 4 hours
Maximum Daily Dose: 75 mg/kg in 24 hours

13 years or older; weight 50 kg or greater: 1000 mg IV every 6 hours OR 650 mg IV every 4 hours
Maximum Single Dose: 1000 mg
Minimum Dosing Interval: every 4 hours
Maximum Daily Dose: 4000 mg in 24 hours

ORAL:
10 to 15 mg/kg orally every 4 to 6 hours as needed not to exceed 5 doses in 24 hours
-Alternatively, use weight first, then age:
2.7 to 5.3 kg (0 to 3 months): 40 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
5.4 to 8.1 kg (4 to 11 months): 80 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
8.2 to 10.8 kg (12 to 23 months): 120 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
10.9 to 16.3 kg (2 to 3 years): 160 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
16.4 to 21.7 kg (4 to 5 years): 240 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
21.8 to 27.2 kg (6 to 8 years): 320 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
27.3 to 32.6 kg (9 to 10 years): 400 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours
32.7 to 43.2 kg (11 to 12 years): 480 mg orally every 4 hours as needed not to exceed 5 doses in 24 hours

12 years or older:
Immediate-release: 325 mg to 1 g orally every 4 to 6 hours
Minimum Dosing Interval: every 4 hours
Maximum Single Dose: 1000 mg
Maximum Dose: 4 g per 24 hours

Extended-Release: 1300 mg orally every 8 hours
Maximum dose: 3900 mg per 24 hours";



            txtDirections.Text = direction;
            txtDose.Text = dose;

        }
    }
}

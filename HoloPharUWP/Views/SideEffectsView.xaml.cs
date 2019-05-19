using DataContainer;
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
    public sealed partial class SideEffectsView : Page
    {
        public SideEffectsView()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string dose = @"skin rash, no matter how mild;

    shortness of breath (even with mild exertion);

    swelling or rapid weight gain;

    signs of stomach bleeding - bloody or tarry stools, coughing up blood or vomit that looks like coffee grounds;

    liver problems - nausea, upper stomach pain, itching, tired feeling, flu-like symptoms, loss of appetite, dark urine, clay-colored stools, jaundice (yellowing of the skin or eyes);

    kidney problems - little or no urinating, painful or difficult urination, swelling in your feet or ankles, feeling tired or short of breath;

    high blood pressure - severe headache, pounding in your neck or ears, nosebleed, anxiety, confusion;

    low red blood cells (anemia) - pale skin, feeling light-headed or short of breath, rapid heart rate, trouble concentrating; or

    severe skin reaction - fever, sore throat, swelling in your face or tongue, burning in your eyes, skin pain followed by a red or purple skin rash that spreads (especially in the face or upper body) and causes blistering and peeling.

Common diclofenac side effects may include:

    indigestion, gas, stomach pain, nausea, vomiting;

    diarrhea, constipation;

    headache, dizziness, drowsiness;

    stuffy nose;

    itching, increased sweating;

    increased blood pressure; or

    swelling or pain in your arms or legs.";
          

            txtSide.Text = dose;

        }
    }
}

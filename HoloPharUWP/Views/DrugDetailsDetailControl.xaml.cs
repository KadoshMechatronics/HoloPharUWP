using HoloPharUWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HoloPharUWP.Views
{
    public sealed partial class DrugDetailsDetailControl : Page
    {
        public SampleModel MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleModel; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleModel), typeof(DrugDetailsDetailControl), new PropertyMetadata(null));

        public DrugDetailsDetailControl()
        {
            InitializeComponent();
        }

        private void PicDrug_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Gen.CurrentUser != null)
            {


                //try
                //{
                //    faceboook.NavigateUri = new System.Uri(Gen.CurrentUser.FB);
                //}
                //catch (Exception)
                //{
                //}
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

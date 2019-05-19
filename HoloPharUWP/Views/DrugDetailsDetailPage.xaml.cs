using System.ComponentModel;
using System.Runtime.CompilerServices;

using HoloPharUWP.Models;
using HoloPharUWP.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace HoloPharUWP.Views
{
    public sealed partial class DrugDetailsDetailPage : Page, INotifyPropertyChanged
    {
        private SampleModel _item;
        public SampleModel Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public DrugDetailsDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Item = e.Parameter as SampleModel;
        }

        private void WindowStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            if (e.OldState == NarrowState && e.NewState == WideState)
            {
                NavigationService.GoBack();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string dose = @"    Amoclav® (containing Amoxicillin, Clavulanate)
    Augmentin® (containing Amoxicillin, Clavulanate)
    Augmentin® XR (containing Amoxicillin, Clavulanate)
    Clavamox® (containing Amoxicillin, Clavulanate)";

            string direction = @"Amoxicillin and Clavulanic Acid";



            txtDirections.Text = direction;
            txtDose.Text = dose;
        }
    }
}

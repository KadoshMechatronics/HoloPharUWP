using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using HoloPharUWP.Models;

namespace HoloPharUWP.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            //Gen.CurrentUser = DataContainer.DataAccess.GetUser(3);
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

        private  void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        { 
         
   if (Gen.CurrentUser == null)
                MySplitView.IsPaneOpen = true;
            else
                this.Frame.Navigate(typeof(PatientInformationDetailControl), null, new EntranceNavigationTransitionInfo());
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Gen.CurrentUser == null)
                MySplitView.IsPaneOpen = true;
            else
                this.Frame.Navigate(typeof(DrugDetailsDetailControl), null, new EntranceNavigationTransitionInfo());
        }


        /// <summary>
        /// history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Gen.CurrentUser == null)
                MySplitView.IsPaneOpen = true;
            else
                Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
            //this.Frame.Navigate(typeof(DrugDetailsDetailControl), null, new EntranceNavigationTransitionInfo());
        }
        private string inputString;


        public static async Task<string> InputTextDialogAsync(string title, string defaultText, string okButtonText, string cancelButtonText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                Text = defaultText,
                SelectionStart = defaultText.Length,
                BorderThickness = new Thickness(1),
                BorderBrush = (SolidColorBrush)Application.Current.Resources["CustomDialogBorderColor"]
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = okButtonText,
                SecondaryButtonText = cancelButtonText
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }

        private  void PersonPicture_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;

            txtPatient.Focus(FocusState.Programmatic);
        }

        private  void picDrug_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
         


            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            txtDrug1.Focus(FocusState.Programmatic);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SideEffectsView), null, new EntranceNavigationTransitionInfo());
        }

        private async void btnDrgs_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stDrugs.Children)
            {
                if (item is AutoSuggestBox)
                {
                    AutoSuggestBox ab = item as AutoSuggestBox;

                    if (ab.Text != "")
                    {
                        Gen.DrugNames.Add(ab.Text);
                    }

                }
            }
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
          
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var drugs = await ww.SuggestDrugAsync(sender.Text);
                sender.ItemsSource = drugs;
            }
        }

        WebMedicalServicesLib.Main ww = new WebMedicalServicesLib.Main();

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DrugInteractions), null, new EntranceNavigationTransitionInfo());
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            
            // ولا اشي
          
           MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnDirections_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(DirectionsView), null, new EntranceNavigationTransitionInfo());
        }

        private void txtPatient_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
        }

        private void txtPatient_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Gen.CurrentUser = DataContainer.DataAccess.GetUser(Convert.ToInt32( args.SelectedItem)) ;

        }

        private void txtPatient_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> userNames = new List<string>();
                var listofUsers = DataContainer.DataAccess.GetUsers();
                foreach (var item in listofUsers)
                {
                    userNames.Add(item.Name); 
                }
                sender.ItemsSource = userNames;
            }
        }

        private async void btnPatientCreate_Click(object sender, RoutedEventArgs e)
        {
            inputString = await InputTextDialogAsync("Enter Patient Mobile", "","Enter","Cancel");
            //DataContainer.DataAccess.UpdateUser(Gen.CurrentUser.ID, inputString);
            Gen.CurrentUser = DataContainer.DataAccess.UserAdd(txtPatient.Text, inputString, "", "");

        }
    }
}

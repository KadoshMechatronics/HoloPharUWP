using HoloPharUWP.Models;
using System;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace HoloPharUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PatientInformationDetailControl : Page
    {
        public SampleModel MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleModel; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleModel), typeof(PatientInformationDetailControl), new PropertyMetadata(null));

        public PatientInformationDetailControl()
        {
            this.InitializeComponent();
        }


        // Gets the rectangle of the element 
        public static Rect GetElementRect(FrameworkElement element)
        {
            // Passing "null" means set to root element. 
            GeneralTransform elementTransform = element.TransformToVisual(null);
            Rect rect = elementTransform.TransformBounds(new Rect(0, 0, element.ActualWidth, element.ActualHeight));
            return rect;
        }

        // Display a contact in response to an event
        private void OnUserClickShowContactCard(object sender, RoutedEventArgs e)
        {
            if (ContactManager.IsShowContactCardSupported())
            {
                Rect selectionRect = GetElementRect((FrameworkElement)sender);

                // Retrieve the contact to display
                var contact = new Contact();
                var email = new ContactEmail();
                email.Address = "jsmith@contoso.com";
                contact.Emails.Add(email);

                ContactManager.ShowContactCard(
                    contact, selectionRect, Placement.Default);
            }
        }

        private void PicDrug_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(Gen.CurrentUser!=null)
            {
                txtAddress.Text = Gen.CurrentUser.Address;
                txtAge.Text = Gen.CurrentUser.Age.ToString();
                txtEmail.Text = Gen.CurrentUser.Email==null?"": Gen.CurrentUser.Email;
                if (Gen.CurrentUser.IsMale)
                    rdMale.IsChecked = true;
                else
                    rdFemale.IsChecked = true;
                txtMobile.Text = Gen.CurrentUser.Mobile;
                txtName.Text = Gen.CurrentUser.Name;
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
            DataContainer.DataAccess.UpdateUser(Gen.CurrentUser.ID, txtMobile.Text, txtName.Text, txtAddress.Text,txtFacebook.Text,txtEmail.Text,rdMale.IsChecked.Value==true?1:0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

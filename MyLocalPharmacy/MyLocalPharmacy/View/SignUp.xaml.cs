using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyLocalPharmacy.ViewModel;
using System.Threading;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Windows.Storage.Streams;
using MyLocalPharmacy.Utils;


namespace MyLocalPharmacy.View
{
    public partial class SignUp : PhoneApplicationPage
    {
        SignUpViewModel vmSignUp;
        bool isNewPageInstance = false;
        TransientDataStorage<string> obj = new TransientDataStorage<string>();

        TransientDataStorage<SignUpViewModel> obj1 = new TransientDataStorage<SignUpViewModel>();
        SignUpViewModel objsgnup = new SignUpViewModel();
        /// <summary>
        /// Constructor
        /// </summary>
        public SignUp()
        {
            InitializeComponent();
            isNewPageInstance = true;
            //objsgnup= obj1.Restore<SignUpViewModel>("x");
            //if (obj1.Restore<SignUpViewModel>("x") != null)
            //{
            //    obj1.Restore<SignUpViewModel>("x");
            //    PharmacyDetailsGrid.Visibility = Visibility.Visible;
            //}
            if (!string.IsNullOrEmpty(obj.Restore<string>("Pharmacyname")))
            {
                NewUserGrid.Visibility = Visibility.Visible;
                NewUserPanel.Visibility = Visibility.Visible;
                PharmacyDetailsGrid.Visibility = Visibility.Visible;
                tbkpharname.Text = obj.Restore<string>("Pharmacyname");
                tbkadd1.Text = obj.Restore<string>("AddressLine1");
                tbkadd2.Text = obj.Restore<string>("AddressLine2");
                tbkpin.Text = obj.Restore<string>("PinCode");
            }
            this.DataContext = vmSignUp;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);
            if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
            {
                State["SignUpViewModel"] = vmSignUp;
                if (!string.IsNullOrEmpty(tbxID.Text))
                    App.SignUpPharId = tbxID.Text;
                if (!string.IsNullOrEmpty(tbxLoginID.Text))
                    App.LoginPharId = tbxLoginID.Text;
                if (!string.IsNullOrEmpty(tbxEmail.Text))
                    App.LoginEmailId = tbxEmail.Text;
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (isNewPageInstance)
            {
                if (vmSignUp == null)
                {
                    if (State.Count > 0)
                    {
                        vmSignUp = (SignUpViewModel)State["SignUpViewModel"];
                    }
                    else
                    {
                        vmSignUp = new SignUpViewModel();
                    }
                }
                DataContext = vmSignUp;
            }


            BaseViewModel viewModel = this.DataContext as BaseViewModel;
            viewModel.Initialize(this.NavigationContext.QueryString);
            isNewPageInstance = false;
        }
        /// <summary>
        /// Navigate to Setup pin page for signup user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPIN_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //  obj1.Backup("x", vmSignUp);
            obj.Backup("Pharmacyname", tbkpharname.Text);
            obj.Backup("AddressLine1", tbkadd1.Text);
            obj.Backup("AddressLine2", tbkadd2.Text);
            obj.Backup("PinCode", tbkpin.Text);

            NavigationService.Navigate(new Uri(PageURL.navigateToSetPinURL, UriKind.Relative));
        }

        /// <summary>
        /// Navigate to enter pin oage for login user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxloginPIN_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri(PageURL.navigateToEnterPinURL, UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            if (popup.IsOpen)
            {
                popup.IsOpen = false;
                LayoutRoot.IsHitTestVisible = true;
                //NavigationService.GoForward();
                // ClosePopup();
                //foreach (var button in ApplicationBar.Buttons)
                //{
                //    ((ApplicationBarIconButton) button).IsEnabled = false;
                //}


                e.Cancel = true;
            }
            
            else
            {
                Exit();
            }
           
        }

        private void Exit()
        {
            while (NavigationService.BackStack.Any())
            {
                NavigationService.RemoveBackEntry();

            }
        }

    }
}
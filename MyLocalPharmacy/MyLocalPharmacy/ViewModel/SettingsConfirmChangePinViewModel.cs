using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Common;
using Microsoft.Phone.Controls;
using System.Windows;
namespace MyLocalPharmacy.ViewModel
{
    public class SettingsConfirmChangePinViewModel : BaseViewModel
    {
        private string _pin;
        public string Pin
        {
            get { return _pin; }
            set
            {
                _pin = value;
                OnPropertyChanged("Pin");
            }
        }
        /// <summary>
        /// Property for navigation to ConfirmPin Page
        /// </summary>
        private RelayCommand _confirmPin;
        public RelayCommand ConfirmPin
        {

            get
            {
                if (_confirmPin == null)
                {
                    _confirmPin = new RelayCommand(NavigateFromConfirmPin);
                    _confirmPin.Enabled = true;
                }

                return _confirmPin;
            }
            set { _confirmPin = value; }
        }


        /// <summary>
        /// Method to navigate to signup screen
        /// </summary>
        private void NavigateFromConfirmPin()
        {
            if (Pin == App.PIN)
            {
                App.PIN = Pin;
                PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                bool success = false;
                // frame.GoBack();
                success = frame.Navigate(new Uri(PageURL.navigateToSettingPageURL, UriKind.Relative));
                if (success)
                {
                    // I'm not sure if the frame's Content property will give you the current view.
                    //IView view = (IView)frame.Content;
                    //IViewModel viewModel = this.unityContainer.Resolve<IViewModel>();
                    //viewModel.View = view;
                }
            }
            else
            {
                MessageBox.Show("Password Mismatch");
                return;
            }

        }
    }
}

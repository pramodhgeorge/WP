using Microsoft.Phone.Controls;
using MyLocalPharmacy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyLocalPharmacy.Utils;

namespace MyLocalPharmacy.ViewModel
{
    public class EnterPinViewModel : BaseViewModel
    {
        public EnterPinViewModel()
        {
            _isPinValidatorVisible = Visibility.Collapsed;
        }

        #region Properties
        /// <summary>
        /// To set the Pin Message
        /// </summary>
        private string _pinLengthMessage;
        public string PinLengthMessage
        {
            get { return _pinLengthMessage; }
            set
            {
                _pinLengthMessage = value;
                OnPropertyChanged("PinLengthMessage");
            }
        }
        /// <summary>
        /// To set the Pin Message Visibilty
        /// </summary>
        private Visibility _isPinValidatorVisible;
        public Visibility IsPinValidatorVisible
        {
            get { return _isPinValidatorVisible; }
            set
            {
                _isPinValidatorVisible = value;
                OnPropertyChanged("IsPinValidatorVisible");
            }
        }
        /// <summary>
        /// To set the Pin
        /// </summary>
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
        private RelayCommand _enterPin;
        public RelayCommand EnterPin
        {

            get
            {
                if (_enterPin == null)
                {
                    _enterPin = new RelayCommand(NavigateBack);
                    _enterPin.Enabled = true;
                }

                return _enterPin;
            }
            set { _enterPin = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method to navigate to signup screen
        /// </summary>
        private void NavigateBack()
        {
            App.PIN = Pin;
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;
            if (Pin != null)
            {
                if (Pin.Length < 4)
                {
                    IsPinValidatorVisible = Visibility.Visible;
                    PinLengthMessage = "Pin should be 4 digits";
                }
                else
                {
                    success = frame.Navigate(new Uri(PageURL.navigateToLoginPanelURL, UriKind.Relative));
                }
            }
            else
            {
                IsPinValidatorVisible = Visibility.Visible;
                PinLengthMessage = "Please enter a PIN";
            }

            if (success)
            {
                // I'm not sure if the frame's Content property will give you the current view.
                //IView view = (IView)frame.Content;
                //IViewModel viewModel = this.unityContainer.Resolve<IViewModel>();
                //viewModel.View = view;
            }
        }
        #endregion        
    }
}

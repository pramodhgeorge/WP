using Microsoft.Phone.Controls;
using MyLocalPharmacy.Common;
using MyLocalPharmacy.Model;
using MyLocalPharmacy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLocalPharmacy.ViewModel
{
    public class ResetPinLoginViewModel : BaseViewModel
    {
        private bool _isValidatedAuth = false;
        private bool _isValidatedPin = false;
        public ResetPinModel ResetPinModel;
        public ResetPinLoginViewModel()
        {
            HitVisibility = true;
            IsAuthCodeValidatorVisible = Visibility.Collapsed;
            IsPinValidatorVisible = Visibility.Collapsed;

            if (string.IsNullOrEmpty(App.resetLoginPIN) || string.IsNullOrWhiteSpace(App.resetLoginPIN))
            {
                IsLoginPasswordBoxVisible = Visibility.Collapsed;
                IsLoginPinTextBoxVisible = Visibility.Visible;
            }
            else
            {
                IsLoginPasswordBoxVisible = Visibility.Visible;
                IsLoginPinTextBoxVisible = Visibility.Collapsed;
                DisplaySignUpPin = App.resetLoginPIN;
            }

            if (!string.IsNullOrEmpty(App.resetLoginAuthCode) || !string.IsNullOrWhiteSpace(App.resetLoginAuthCode) )
            {
                AuthCode = App.resetLoginAuthCode;
            }
        }

        

        #region Validator Properties
        /// <summary>
        /// Show validation border over Pin control
        /// </summary>
        private Thickness _pinBorder;
        public Thickness PinBorder
        {
            get { return _pinBorder; }
            set { _pinBorder = value; OnPropertyChanged("PinBorder"); }
        }

        /// <summary>
        /// Show validation border over Auth Code control
        /// </summary>
        private Thickness _authCodeBorder;
        public Thickness AuthCodeBorder
        {
            get { return _authCodeBorder; }
            set { _authCodeBorder = value; OnPropertyChanged("AuthCodeBorder"); }
        }

        /// <summary>
        /// Show the AuthCode validator
        /// </summary>
        private Visibility _isAuthCodeValidatorVisible;
        public Visibility IsAuthCodeValidatorVisible
        {
            get { return _isAuthCodeValidatorVisible; }
            set { _isAuthCodeValidatorVisible = value; OnPropertyChanged("IsAuthCodeValidatorVisible"); }
        }

        /// <summary>
        /// Show the Pin validator
        /// </summary>
        private Visibility _isPinValidatorVisible;
        public Visibility IsPinValidatorVisible
        {
            get { return _isPinValidatorVisible; }
            set { _isPinValidatorVisible = value; OnPropertyChanged("IsPinValidatorVisible"); }
        } 
        #endregion

        /// <summary>
        /// Property to set hit visibility
        /// </summary>
        private bool _hitVisibility;
        public bool HitVisibility
        {
            get { return _hitVisibility; }
            set { _hitVisibility = value; OnPropertyChanged("HitVisibility"); }
        }

        /// <summary>
        /// Property to set the SignUp PIN
        /// </summary>
        private string _displaySignUpPin;
        public string DisplaySignUpPin
        {
            get { return _displaySignUpPin; }
            set { _displaySignUpPin = value; OnPropertyChanged("DisplaySignUpPin"); }
        }

        /// <summary>
        /// Property to show and hide popup "Incorrect Code" 
        /// </summary>
        private string _isIncorrectPopupOpen;

        public string IsIncorrectPopupOpen
        {
            get { return _isIncorrectPopupOpen; }
            set { _isIncorrectPopupOpen = value; OnPropertyChanged("IsIncorrectPopupOpen"); }
        }

        /// <summary>
        /// Property to show and hide popup "Code has been reset" 
        /// </summary>
        private string _isResetPopupOpen;

        public string IsResetPopupOpen
        {
            get { return _isResetPopupOpen; }
            set { _isResetPopupOpen = value; OnPropertyChanged("IsResetPopupOpen"); }
        }

        /// <summary>
        /// Property to show and hide popup "no such user" 
        /// </summary>
        private string _isNoUserPopupOpen;

        public string IsNoUserPopupOpen
        {
            get { return _isNoUserPopupOpen; }
            set { _isNoUserPopupOpen = value; OnPropertyChanged("IsNoUserPopupOpen"); }
        }

        /// <summary>
        /// Property to show and hide popup "No Internet Connectivity" 
        /// </summary>
        private string _isNoInternetPopupOpen;

        public string IsNoInternetPopupOpen
        {
            get { return _isNoInternetPopupOpen; }
            set { _isNoInternetPopupOpen = value; OnPropertyChanged("IsNoInternetPopupOpen"); }
        }

        /// <summary>
        /// Property to set PIN PasswordBox Visibility in ResetPinLogin screen
        /// </summary>
        private Visibility _isLoginPasswordBoxVisible;
        public Visibility IsLoginPasswordBoxVisible
        {
            get { return _isLoginPasswordBoxVisible; }
            set { _isLoginPasswordBoxVisible = value; OnPropertyChanged("IsLoginPasswordBoxVisible"); }
        }

        /// <summary>
        /// Property to set PIN TextBox Visibility in ResetPinLogin screen
        /// </summary>
        private Visibility _isLoginPinTextBoxVisible;
        public Visibility IsLoginPinTextBoxVisible
        {
            get { return _isLoginPinTextBoxVisible; }
            set { _isLoginPinTextBoxVisible = value; OnPropertyChanged("IsLoginPinTextBoxVisible"); }
        }

        /// <summary>
        /// Property to get and set Email
        /// </summary>
        private string _loginEmail;
        public string LoginEmail
        {
            get { return _loginEmail; }
            set { _loginEmail = value; OnPropertyChanged("LoginEmail"); }
        }

        /// <summary>
        /// Property to get and set Authrisation code
        /// </summary>
        private string _authCode;
        public string AuthCode
        {
            get { return _authCode; }
            set { _authCode = value; OnPropertyChanged("AuthCode"); }
        }

        /// <summary>
        /// Property for Ok button in popup "Incorrect Authorisation code"
        /// </summary>
        private RelayCommand _IncorrectOkCommand;

        public RelayCommand IncorrectOkCommand
        {
            get
            {
                if (_IncorrectOkCommand == null)
                {

                    _IncorrectOkCommand = new RelayCommand(IncorrectOk);
                    _IncorrectOkCommand.Enabled = true;


                }
                return _IncorrectOkCommand;
            }
            set
            {
                _IncorrectOkCommand = value;
            }
        }

        /// <summary>
        /// Property for Ok button in popup "No such user"
        /// </summary>
        private RelayCommand _NoUserOkCommand;

        public RelayCommand NoUserOkCommand
        {
            get
            {
                if (_NoUserOkCommand == null)
                {

                    _NoUserOkCommand = new RelayCommand(NoUserOk);
                    _NoUserOkCommand.Enabled = true;


                }
                return _NoUserOkCommand;
            }
            set
            {
                _NoUserOkCommand = value;
            }
        }

        /// <summary>
        /// Property for Ok button in popup "No Internet Connectivity"
        /// </summary>
        private RelayCommand _NoInternetOkCommand;

        public RelayCommand NoInternetOkCommand
        {
            get
            {
                if (_NoInternetOkCommand == null)
                {

                    _NoInternetOkCommand = new RelayCommand(NoInternetOk);
                    _NoInternetOkCommand.Enabled = true;


                }
                return _NoInternetOkCommand;
            }
            set
            {
                _NoInternetOkCommand = value;
            }
        }


        /// <summary>
        /// Property for Ok button in popup "Reset Done"
        /// </summary>
        private RelayCommand _resetOkCommand;

        public RelayCommand ResetOkCommand
        {
            get
            {
                if (_resetOkCommand == null)
                {

                    _resetOkCommand = new RelayCommand(ResetOk);
                    _resetOkCommand.Enabled = true;


                }
                return _resetOkCommand;
            }
            set
            {
                _IncorrectOkCommand = value;
            }
        }

       

        /// <summary>
        /// Property for Ok button in Appbar
        /// </summary>
        private RelayCommand _VerifiedOkCommand;

        public RelayCommand VerifiedOkCommand
        {
            get
            {
                if (_VerifiedOkCommand == null)
                {

                    _VerifiedOkCommand = new RelayCommand(VerifiedOk);
                    _VerifiedOkCommand.Enabled = true;


                }
                return _VerifiedOkCommand;
            }
            set
            {
                _VerifiedOkCommand = value;
            }
        }

        private void VerifiedOk()
        {
            ValidateControls();
            
            
            if (_isValidatedAuth == true && _isValidatedPin == true)
            {
                if (Utilities.IsConnectedToNetwork())
                {
                    //AuthCode = "FSA0KGL3";
                    DisplaySignUpPin = App.resetLoginPIN;
                    LoginEmail = App.LoginEmailId;
                    //IsIncorrectPopupOpen = "true";
                    ResetPinModel = new ResetPinModel(this);
                }

                else
                {
                    IsNoInternetPopupOpen = "true";
                    HitVisibility = false;
                }
            }
            
        }

        /// <summary>
        /// Method to validate Controls
        /// </summary>
        private void ValidateControls()
        {
            if (string.IsNullOrEmpty(AuthCode) || string.IsNullOrWhiteSpace(AuthCode))
            {
                AuthCodeBorder = new Thickness(1.5);
                IsAuthCodeValidatorVisible = Visibility.Visible;
                _isValidatedAuth = false;
                
               
            }
            else
            {
                AuthCodeBorder = new Thickness(0);
                IsAuthCodeValidatorVisible = Visibility.Collapsed;
                _isValidatedAuth = true;
            }
            if (string.IsNullOrEmpty(DisplaySignUpPin) || string.IsNullOrWhiteSpace(DisplaySignUpPin))
            {
                PinBorder = new Thickness(1.5);
                IsPinValidatorVisible = Visibility.Visible;
                _isValidatedPin = false;
                
            }
            else
            {
                PinBorder = new Thickness(0);
                
                IsPinValidatorVisible = Visibility.Collapsed;
                _isValidatedPin = true;
            }
        }

        private void ResetOk()
        {
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;
            // frame.GoBack();  
            success = frame.Navigate(new Uri(PageURL.navigateToLoginPanelURL, UriKind.Relative));
            HitVisibility = true;
        }

        private void NoUserOk()
        {
            //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //bool success = false;
            //// frame.GoBack();  
            //success = frame.Navigate(new Uri(PageURL.navigateToLoginPanelURL, UriKind.Relative));
            IsNoUserPopupOpen = "false";
            HitVisibility = true;
        }


        private void IncorrectOk()
        {
            IsIncorrectPopupOpen = "false";
            HitVisibility = true;

            //IsResetPopupOpen = "true";
        }


        private void NoInternetOk()
        {

            IsNoInternetPopupOpen = "false";
            HitVisibility = true;
           
        }
    }
}

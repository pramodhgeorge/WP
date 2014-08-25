using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLocalPharmacy.Common;
using Microsoft.Phone.Controls;
using System.Windows;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Model;
namespace MyLocalPharmacy.ViewModel
{
    public class VerifyBySmsViewModel : BaseViewModel
    {
        //private bool _isValidatedAuth = false;
        public VerifyBySmsViewModel()
        {
            IsAuthCodeValidatorVisible = Visibility.Collapsed; 
        }
        /// <summary>
        /// Property to show and hide popup "Code already sent" 
        /// </summary>
        private string _isRequestPopupOpen;
        public VerifyBySmsModel VerifyBySmsModel;
        public string IsRequestPopupOpen
        {
            get { return _isRequestPopupOpen; }
            set { _isRequestPopupOpen = value; OnPropertyChanged("IsRequestPopupOpen"); }
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
        /// Property to get and set Authrisation code
        /// </summary>
        private string _authCode;
        public string AuthCode
        {
            get { return _authCode; }
            set { _authCode = value; OnPropertyChanged("AuthCode"); }
        }

        /// <summary>
        /// Property to show and hide popup "Code Resent" 
        /// </summary>
        private string _isResentPopupOpen;

        public string IsResentPopupOpen
        {
            get { return _isResentPopupOpen; }
            set { _isResentPopupOpen = value; OnPropertyChanged("IsResentPopupOpen"); }
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
        /// Property to show and hide popup "Verified" 
        /// </summary>
        private string _isVerifiedPopupOpen;

        public string IsVerifiedPopupOpen
        {
            get { return _isVerifiedPopupOpen; }
            set { _isVerifiedPopupOpen = value; OnPropertyChanged("IsVerifiedPopupOpen"); }
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
        /// Property for Resend sms Button
        /// </summary>
        private RelayCommand _ResendCommand;

        public RelayCommand ResendCommand
        {
            get
            {
                if (_ResendCommand == null)
                {

                    _ResendCommand = new RelayCommand(ResendCode);
                    _ResendCommand.Enabled = true;


                }
                return _ResendCommand;
            }
            set
            {
                _ResendCommand = value;
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
        /// Property for Ok button in popup "Wait for few minutes"
        /// </summary>
        private RelayCommand _WaitOkCommand;

        public RelayCommand WaitOkCommand
        {
            get
            {
                if (_WaitOkCommand == null)
                {

                    _WaitOkCommand = new RelayCommand(WaitOk);
                    _WaitOkCommand.Enabled = true;


                }
                return _WaitOkCommand;
            }
            set
            {
                _WaitOkCommand = value;
            }
        }

        /// <summary>
        /// Property for Ok button in popup "Code Sent"
        /// </summary>
        private RelayCommand _ResentOkCommand;

        public RelayCommand ResentOkCommand
        {
            get
            {
                if (_ResentOkCommand == null)
                {

                    _ResentOkCommand = new RelayCommand(ResentOk);
                    _ResentOkCommand.Enabled = true;


                }
                return _ResentOkCommand;
            }
            set
            {
                _ResentOkCommand = value;
            }
        }

        /// <summary>
        /// Property for Ok button in popup "Incorrect SMS code"
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
        /// Property for Ok button in popup "Verified"
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


        /// <summary>
        /// Property for Verify Button
        /// </summary>
        private RelayCommand _VerifyCommand;

        public RelayCommand VerifyCommand
        {
            get
            {
                if (_VerifyCommand == null)
                {

                    _VerifyCommand = new RelayCommand(Verify);
                    _VerifyCommand.Enabled = true;


                }
                return _VerifyCommand;
            }
            set
            {
                _VerifyCommand = value;
            }
        }



        /// <summary>
        /// Method of Relay Command ResendCommand
        /// </summary>
        private void ResendCode()
        {
            

            

                if (Utilities.IsConnectedToNetwork())
                {
                    //AuthCode = "FSA0KGL3";
                    //DisplaySignUpPin = App.resetLoginPIN;
                    //LoginEmail = App.LoginEmailId;
                    //IsIncorrectPopupOpen = "true";

                    VerifyBySmsModel = new VerifyBySmsModel(this, "ResentPin");


                }

                else
                {
                    IsNoInternetPopupOpen = "true";
                    //HitVisibility = false;
                }
           

            //IsRequestPopupOpen = "true";
            //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //frame.Navigate(new Uri("/View/FindService.xaml", UriKind.Relative));
            

        }

      

        /// <summary>
        /// Method of Relay Command ResendCommand
        /// </summary>
        private void WaitOk()
        {
            IsRequestPopupOpen = "false";
            //IsResentPopupOpen = "true";
            //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //frame.Navigate(new Uri("/View/FindService.xaml", UriKind.Relative));
        }

       
        /// <summary>
        /// Method of Relay Command ResentOkCommand
        /// </summary>
        private void ResentOk()
        {
            IsResentPopupOpen = "false";
            //IsRequestPopupOpen = "false";
            //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //frame.Navigate(new Uri("/View/FindService.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Method of Relay Command IncorrectOkCommand
        /// </summary>
        private void IncorrectOk()
        {
            IsIncorrectPopupOpen = "false";
            IsVerifiedPopupOpen = "true";
            //IsResentPopupOpen = "false";
            //IsRequestPopupOpen = "false";
            //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //frame.Navigate(new Uri("/View/FindService.xaml", UriKind.Relative));
        }        

        

        /// <summary>
        /// Method of Relay Command VerifiedOkCommand
        /// </summary>
        private void VerifiedOk()
        {
            IsVerifiedPopupOpen = "false";
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            frame.Navigate(new Uri(PageURL.navigateToHomePanoramaURL, UriKind.Relative));
            
        }      

        /// <summary>
        /// Method of Relay Command VerifyCommand
        /// </summary>
        private void Verify()
        {
            if (string.IsNullOrEmpty(AuthCode) || string.IsNullOrWhiteSpace(AuthCode))
            {
                AuthCodeBorder = new Thickness(1.5);
                IsAuthCodeValidatorVisible = Visibility.Visible;

                //Write the Code here for is connected to internet
            }

            else
            {
                AuthCodeBorder = new Thickness(0);
                IsAuthCodeValidatorVisible = Visibility.Collapsed;
                
            }
            //IsRequestPopupOpen = "false";
            //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //frame.Navigate(new Uri("/View/FindService.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Method of No Internet Ok Command
        /// </summary>
        private void NoInternetOk()
        {

            IsNoInternetPopupOpen = "false";
            //HitVisibility = true;

        }
    }
}
        
    
    
    


﻿using System;
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
    public class VerificationViewModel : BaseViewModel
    {
        VerificationModel VerificationModel;
        /// <summary>
        /// Constructor
        /// </summary>
        public VerificationViewModel()
        {
            
            //_isOpenCommand = iso
        }

        /// <summary>
        /// Property for OK button of popup "Verified"
        /// </summary>
        private RelayCommand _OkCommand;
        
        public RelayCommand OkCommand
        {
            get
            {
                if (_OkCommand == null)
                {

                    _OkCommand = new RelayCommand(SubmitOk);
                    _OkCommand.Enabled = true;


                }
                return _OkCommand;
            }
            set
            {
                _OkCommand = value;
            }
        }

        /// <summary>
        /// Property for OK button of popup "Confirmation sent"
        /// </summary>
        private RelayCommand _ConfirmationOkCommand;

        public RelayCommand ConfirmationOkCommand
        {
            get
            {
                if (_ConfirmationOkCommand == null)
                {

                    _ConfirmationOkCommand = new RelayCommand(ConfirmationSubmitOk);
                    _ConfirmationOkCommand.Enabled = true;


                }
                return _ConfirmationOkCommand;
            }
            set
            {
                _ConfirmationOkCommand = value;
            }
        }


        /// <summary>
        /// Property for Resend email button
        /// </summary>
        private RelayCommand _ResendCommand;

        public RelayCommand ResendCommand
        {
            get
            {
                if (_ResendCommand == null)
                {

                    _ResendCommand = new RelayCommand(ResendMail);
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
        /// Property for OK button of popup "Email resent"
        /// </summary>
        private RelayCommand _ResendOkCommand;

        public RelayCommand ResendOkCommand
        {
            get
            {
                if (_ResendOkCommand == null)
                {

                    _ResendOkCommand = new RelayCommand(ResendMailOk);
                    _ResendOkCommand.Enabled = true;


                }
                return _ResendOkCommand;
            }
            set
            {
                _ResendOkCommand = value;
            }
        }

        /// <summary>
        /// Property to show and hide popup "Verified"
        /// </summary>
        private string _isConfirmationPopupOpen;

        public string IsConfirmationPopupOpen
        {
            get { return _isConfirmationPopupOpen; }
            set { _isConfirmationPopupOpen = value; OnPropertyChanged("IsConfirmationPopupOpen"); }
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
        /// Property to show and hide popup 
        /// </summary>
        private string _isPopupOpen;

        public string IsPopupOpen
        {
            get { return _isPopupOpen; }
            set { _isPopupOpen = value; OnPropertyChanged("IsPopupOpen"); }
        }

        /// <summary>
        /// Property to show and hide popup "Email Resent"
        /// </summary>
        private string _isResendPopupOpen;

        public string IsResendPopupOpen
        {
            get { return _isResendPopupOpen; }
            set { _isResendPopupOpen = value; OnPropertyChanged("IsResendPopupOpen"); }
        }
        
        
        /// <summary>
        /// Method of Relay Command OkCommand
        /// </summary>
        private void SubmitOk()
        {
            IsPopupOpen = "false";
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            frame.Navigate(new Uri(PageURL.navigateToHomePanoramaURL, UriKind.Relative));
        }

        /// <summary>
        /// Method of Relay Command ConfirmationOkCommand
        /// </summary>
        private void ConfirmationSubmitOk()
        {
            IsConfirmationPopupOpen = "false";
            //IsResendPopupOpen = "true";
        }

        /// <summary>
        /// Method of Relay Command ResendCommand
        /// </summary>
        private void ResendMail()
        {


            if (Utilities.IsConnectedToNetwork())
            {
                //AuthCode = "FSA0KGL3";
                //DisplaySignUpPin = App.resetLoginPIN;
                //LoginEmail = App.LoginEmailId;
                //IsIncorrectPopupOpen = "true";

                VerificationModel = new VerificationModel(this);


            }

            else
            {
                IsNoInternetPopupOpen = "true";
                //HitVisibility = false;
            }
            //IsConfirmationPopupOpen = "true";
        }

        /// <summary>
        /// Method of Relay Command ResendOkCommand
        /// </summary>
        private void ResendMailOk()
        {
            IsResendPopupOpen = "false";
            //IsPopupOpen = "true";
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

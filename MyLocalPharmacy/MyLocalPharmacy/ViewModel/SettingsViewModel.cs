using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Common;

namespace MyLocalPharmacy.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Property for YourDetails click
        /// </summary>
        private RelayCommand _yourdetailsupdate;
        public RelayCommand UpdateDetails
        {
            get
            {
                if (_yourdetailsupdate == null)
                {

                    _yourdetailsupdate = new RelayCommand(UpdateYourDetails);
                    _yourdetailsupdate.Enabled = true;
                }
                return _yourdetailsupdate;
            }
            set
            {
                _yourdetailsupdate = value;
            }
        }

        

        /// <summary>
        /// Property for ChangePIN click
        /// </summary>
        private RelayCommand _changePIN;
        public RelayCommand ChangePIN
        {
            get
            {
                if (_changePIN == null)
                {

                    _changePIN = new RelayCommand(PINChange);
                    _changePIN.Enabled = true;
                }
                return _changePIN;
            }
            set
            {
                _changePIN = value;
            }
        }

       

        /// <summary>
        /// Property for LocalServices click
        /// </summary>
        private RelayCommand _localserviceDistance;
        public RelayCommand LocalServiceDistance
        {
            get
            {
                if (_localserviceDistance == null)
                {

                    _localserviceDistance = new RelayCommand(LocalServicesDistance);
                    _localserviceDistance.Enabled = true;
                }
                return _localserviceDistance;
            }
            set
            {
                _localserviceDistance = value;
            }
        }

      

        /// <summary>
        /// Property for Terms&Conditions click
        /// </summary>
        private RelayCommand _termsconditions;
        public RelayCommand TermsConditions
        {
            get
            {
                if (_termsconditions == null)
                {

                    _termsconditions = new RelayCommand(TermsandConditions);
                    _termsconditions.Enabled = true;
                }
                return _termsconditions;
            }
            set
            {
                _termsconditions = value;
            }
        }

        

        /// <summary>
        /// Property for Support click
        /// </summary>
        private RelayCommand _support;
        public RelayCommand Support
        {
            get
            {
                if (_support == null)
                {

                    _support = new RelayCommand(SupportPage);
                    _support.Enabled = true;
                }
                return _support;
            }
            set
            {
                _support = value;
            }
        }

        /// <summary>
        /// Property for OK button of popup 
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
        /// Property for Cancel button of popup 
        /// </summary>
        private RelayCommand _cancelCommand;

        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {

                    _cancelCommand = new RelayCommand(Cancel);
                    _cancelCommand.Enabled = true;


                }
                return _cancelCommand;
            }
            set
            {
                _cancelCommand = value;
            }
        }
      
        /// <summary>
        /// Property set distance in miles
        /// </summary>
        private string _milesDistance;

        public string MilesDistance
        {
            get { return _milesDistance; }
            set { _milesDistance = value; OnPropertyChanged("MilesDistance"); }
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
        #endregion

        #region Methods
        /// <summary>
        /// Method of Relay Command CancelCommand
        /// </summary>
        private void Cancel()
        {
            IsPopupOpen = "false";
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            frame.Navigate(new Uri(PageURL.navigateToSettingPageURL, UriKind.Relative));
        }
        /// <summary>
        /// Method of Relay Command OkCommand
        /// </summary>
        private void SubmitOk()
        {
            IsPopupOpen = "false";
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            //frame.Navigate(new Uri(PageURL.navigateToHomePanoramaURL, UriKind.Relative));
        }
        /// <summary>
        /// Method to Update Details
        /// </summary>
        private void UpdateYourDetails()
        {
            
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;

            success = frame.Navigate(new Uri(PageURL.navigateToYourDetailsUpdateURL, UriKind.Relative));

            if (success)
            {
                // I'm not sure if the frame's Content property will give you the current view.
                //IView view = (IView)frame.Content;
                //IViewModel viewModel = this.unityContainer.Resolve<IViewModel>();
                //viewModel.View = view;
            }
        }
        /// <summary>
        /// Method to ChangePIN
        /// </summary>
        private void PINChange()
        {
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;

            success = frame.Navigate(new Uri(PageURL.navigateToSettingsChangePinURL, UriKind.Relative));

            if (success)
            {
                // I'm not sure if the frame's Content property will give you the current view.
                //IView view = (IView)frame.Content;
                //IViewModel viewModel = this.unityContainer.Resolve<IViewModel>();
                //viewModel.View = view;
            }
        }
        /// <summary>
        /// Method to get local services based on distance
        /// </summary>
        private void LocalServicesDistance()
        {
            IsPopupOpen = "true";
        }
        /// <summary>
        /// Method to show the Terms and Condition
        /// </summary>
        private void TermsandConditions()
        {
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;

            success = frame.Navigate(new Uri(PageURL.navigateToTermsandConditionURL, UriKind.Relative));

            if (success)
            {
                // I'm not sure if the frame's Content property will give you the current view.
                //IView view = (IView)frame.Content;
                //IViewModel viewModel = this.unityContainer.Resolve<IViewModel>();
                //viewModel.View = view;
            }
        }
        /// <summary>
        /// Method to navigate to Support page
        /// </summary>
        private void SupportPage()
        {
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;

            success = frame.Navigate(new Uri(PageURL.navigateToPharmacySupportURL, UriKind.Relative));

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

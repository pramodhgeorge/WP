﻿using Microsoft.Phone.Controls;
using MyLocalPharmacy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Entities;
using MyLocalPharmacy.Model;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace MyLocalPharmacy.ViewModel
{
    public class YourDetailswithTCViewModel : BaseViewModel
    {
        public YourDetailswithTCModel objydtcModel;
        public SignUpModel objSgnUpModel;

        ObservableCollection<string> countries = new ObservableCollection<string>();
            
        /// <summary>
        /// Constructor
        /// </summary>
        public YourDetailswithTCViewModel()
        {
            _isFemaleSelected = true;
            ButtonValue = "Choose your doctor surgery(optional)";
            HideAllValidators();
            _isPopupOpen = "false";
            _isSuccessPopupOpen = "false";
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public YourDetailswithTCViewModel(LoginResponse objlgresponse)
        {
            PopulateCountry();
            if (App.Objbrandingesponse != null)
            {
                GetPharmacyInformationResponse objbrandinfo = new GetPharmacyInformationResponse();
                objbrandinfo = App.Objbrandingesponse;
                //objSgnUpModel = new SignUpModel(this,"BrandingInfo");
                PrimaryColour = Utilities.GetColorFromHexa(App.Objbrandingesponse.payload.branding_data.appearance.primary_colour);
                SecondaryColour = Utilities.GetColorFromHexa(App.Objbrandingesponse.payload.branding_data.appearance.secondary_colour);
                FontColor = Utilities.GetColorFromHexa(App.Objbrandingesponse.payload.branding_data.appearance.font_colour);
            }
            NominationStatus = objlgresponse.payload.status;
            string fullname=objlgresponse.payload.name;
            string[] splitfullname = fullname.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            FirstName = splitfullname[0];
            LastName = splitfullname[1];
            AddressLine1 = objlgresponse.payload.address1;
            AddressLine2 = objlgresponse.payload.address2;
            if (countries != null)
            {
                int position = countries.IndexOf(objlgresponse.payload.country);
                PickerSelectedIndex = position;
            }

            //SelectedCountry = objlgresponse.payload.country;
            PostCode = objlgresponse.payload.postcode;
            DOB = objlgresponse.payload.birthdate;
            NHS = objlgresponse.payload.nhs;
            MobileNo = objlgresponse.payload.phone;
            EmailId = objlgresponse.payload.mail;
            ButtonValue = objlgresponse.payload.surgery.name + "-" + objlgresponse.payload.address1;
            if (objlgresponse.payload.verifyby == "mail")
            {

            }
            // CheckedorNot= objlgresponse.payload.verifyby
            if (objlgresponse.payload.sex == 1)
            {
                IsMaleSelected = true;
            }
            else
            {
                IsFemaleSelected = true;
            }
        }
        /// <summary>
        /// Hide  All the Validators when page loads
        /// </summary>
        private void HideAllValidators()
        {
           
            IsAddressLine1ValidatorVisible = Visibility.Collapsed;
            IsAddressLine2ValidatorVisible = Visibility.Collapsed;
            IsAddressLine3ValidatorVisible = Visibility.Collapsed;
            IsPostCodeValidatorVisible = Visibility.Collapsed;
          
            IsMobilePhoneValidatorVisible = Visibility.Collapsed;
            IsTCValidatorVisible = Visibility.Collapsed;
        }
        /// <summary>
        /// Method to populate countries
        /// </summary>
        private void PopulateCountry()
        {
            countries.Add("Please Select a Country *");
            countries.Add("England");
            countries.Add("Wales");
            countries.Add("Scotland");
            countries.Add("Northern Ireland");
            Listitems = countries;
        }
        #region Properties
        /// <summary>
        /// Property to set progressbar rowno
        /// </summary>
        private string _progressBarRowNo;
        public string ProgressBarRowNo
        {
            get { return _progressBarRowNo; }
            set { _progressBarRowNo = value; OnPropertyChanged("ProgressBarRowNo"); }
        }
        /// <summary>
        /// Set progress bar visibility
        /// </summary>
        private Visibility _progressBarVisibilty = Visibility.Collapsed;
        public Visibility ProgressBarVisibilty
        {
            get
            {
                return _progressBarVisibilty;
            }
            set
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    _progressBarVisibilty = value;
                    OnPropertyChanged("ProgressBarVisibilty");
                });

            }
        }
        /// <summary>
        /// set selected country
        /// </summary>
        private string _selectedCountry;
        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (value != _selectedCountry)
                {
                    _selectedCountry = value;
                    
                    OnPropertyChanged("SelectedCountry");
                }
            }
        }
        /// <summary>
        /// set the selected index
        /// </summary>
        private int _pickerSelectedIndex = 0;
        public int PickerSelectedIndex
        {
            get
            {
                return this._pickerSelectedIndex;
            }
            set
            {
                this._pickerSelectedIndex = value; OnPropertyChanged("PickerSelectedIndex");
            }
        }
        /// <summary>
        /// Property to populate country
        /// </summary>
        private ObservableCollection<string> _listitems;
        public ObservableCollection<string> Listitems
        {
            get { return _listitems; }
            set { _listitems = value; OnPropertyChanged("Listitems"); this.PickerSelectedIndex = 0; }
        }
        /// <summary>
        /// For Font Color
        /// </summary>
        private SolidColorBrush _fontColor; //= new SolidColorBrush(Utilities.GetColorFromHexa(""));
        public SolidColorBrush FontColor
        {
            get { return _fontColor; }
            set
            {
                _fontColor = value;
                OnPropertyChanged("FontColor");
            }
        }
        /// <summary>
        /// For Primary Color
        /// </summary>
        private SolidColorBrush _primaryColour; //= new SolidColorBrush(Utilities.GetColorFromHexa(""));
        public SolidColorBrush PrimaryColour
        {
            get { return _primaryColour; }
            set
            {
                _primaryColour = value;
                OnPropertyChanged("PrimaryColour");
            }
        }
        /// <summary>
        /// For Secondary Color
        /// </summary>
        private SolidColorBrush _secondaryColour; //= new SolidColorBrush(Utilities.GetColorFromHexa(""));
        public SolidColorBrush SecondaryColour
        {
            get { return _secondaryColour; }
            set
            {
                _secondaryColour = value;
                OnPropertyChanged("SecondaryColour");
            }
        }
        /// <summary>
        /// For Splash url
        /// </summary>
        private string _splashurl; 
        public string SplashUrl
        {
            get { return _splashurl; }
            set
            {
                _splashurl = value;
                OnPropertyChanged("SplashUrl");
            }
        }
        /// <summary>
        /// Set Nomination Status
        /// </summary>
        private string _nominationStatus;
        public string NominationStatus
        {
            get { return _nominationStatus; }
            set { _nominationStatus = value; OnPropertyChanged("NominationStatus"); }
        }
        /// <summary>
        /// For First name
        /// </summary>
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }
        /// <summary>
        /// For Last name
        /// </summary>
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }
        /// <summary>
        /// For Address Line1
        /// </summary>
        private string _addressLine1;
        public string AddressLine1
        {
            get
            {
                return _addressLine1;
            }
            set
            {
                _addressLine1 = value;
                OnPropertyChanged("AddressLine1");
            }
        }
        /// <summary>
        /// Show Address Line1 message
        /// </summary>
        private string _addressLine1Message;
        public string AddressLine1Message
        {
            get { return _addressLine1Message; }
            set { _addressLine1Message = value; OnPropertyChanged("AddressLine1Message"); }
        }
        /// <summary>
        /// Show Address  Line1 validator
        /// </summary>
        private Visibility _isAddressLine1ValidatorVisible;
        public Visibility IsAddressLine1ValidatorVisible
        {
            get { return _isAddressLine1ValidatorVisible; }
            set { _isAddressLine1ValidatorVisible = value; OnPropertyChanged("IsAddressLine1ValidatorVisible"); }
        }
        /// <summary>
        /// Show validation border over Address Line1 control
        /// </summary>
        private Thickness _addresLine1Border;
        public Thickness AddresLine1Border
        {
            get { return _addresLine1Border; }
            set { _addresLine1Border = value; OnPropertyChanged("AddresLine1Border"); }
        }
        /// <summary>
        /// For Address Line2
        /// </summary>
        private string _addressLine2;
        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; OnPropertyChanged("AddressLine2"); }
        }
        /// <summary>
        /// Show Address Line2 message
        /// </summary>
        private string _addressLine2Message;
        public string AddressLine2Message
        {
            get { return _addressLine2Message; }
            set { _addressLine2Message = value; OnPropertyChanged("AddressLine2Message"); }
        }
        /// <summary>
        /// Show Address  Line2 validator
        /// </summary>
        private Visibility _isAddressLine2ValidatorVisible;
        public Visibility IsAddressLine2ValidatorVisible
        {
            get { return _isAddressLine2ValidatorVisible; }
            set { _isAddressLine2ValidatorVisible = value; OnPropertyChanged("IsAddressLine2ValidatorVisible"); }
        }
        /// <summary>
        /// Show validation border over Address Line2 control
        /// </summary>
        private Thickness _addresLine2Border;
        public Thickness AddresLine2Border
        {
            get { return _addresLine2Border; }
            set { _addresLine2Border = value; OnPropertyChanged("AddresLine2Border"); }
        }
        /// <summary>
        /// For Address Line3
        /// </summary>
        private string _addressLine3;
        public string AddressLine3
        {
            get { return _addressLine3; }
            set { _addressLine3 = value; OnPropertyChanged("AddressLine3"); }
        }
        /// <summary>
        /// Show Address Line3 message
        /// </summary>
        private string _addressLine3Message;
        public string AddressLine3Message
        {
            get { return _addressLine3Message; }
            set { _addressLine3Message = value; OnPropertyChanged("AddressLine3Message"); }
        }
        /// <summary>
        /// Show Address  Line3 validator
        /// </summary>
        private Visibility _isAddressLine3ValidatorVisible;
        public Visibility IsAddressLine3ValidatorVisible
        {
            get { return _isAddressLine3ValidatorVisible; }
            set { _isAddressLine3ValidatorVisible = value; OnPropertyChanged("IsAddressLine3ValidatorVisible"); }
        }
        /// <summary>
        /// Show validation border over Address Line3 control
        /// </summary>
        private Thickness _addresLine3Border;
        public Thickness AddresLine3Border
        {
            get { return _addresLine3Border; }
            set { _addresLine3Border = value; OnPropertyChanged("AddresLine3Border"); }
        }
        /// <summary>
        /// For Post Code
        /// </summary>
        private string _postCode;
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; OnPropertyChanged("PostCode"); }
        }
        /// <summary>
        /// For Post Code validation message
        /// </summary>
        private string _postCodeMessage;
        public string PostCodeMessage
        {
            get { return _postCodeMessage; }
            set { _postCodeMessage = value; OnPropertyChanged("PostCodeMessage"); }
        }
        /// <summary>
        /// Show Post code validator
        /// </summary>
        private Visibility _isPostCodeValidatorVisible;
        public Visibility IsPostCodeValidatorVisible
        {
            get { return _isPostCodeValidatorVisible; }
            set { _isPostCodeValidatorVisible = value; OnPropertyChanged("IsPostCodeValidatorVisible"); }
        }
        /// <summary>
        /// Show validation border over post code control
        /// </summary>
        private Thickness _postCodeBorder;
        public Thickness PostCodeBorder
        {
            get { return _postCodeBorder; }
            set { _postCodeBorder = value; OnPropertyChanged("PostCodeBorder"); }
        }
        /// <summary>
        /// For DOB
        /// </summary>
        private string _dob;
        public string DOB
        {
            get { return _dob; }
            set { _dob = value; OnPropertyChanged("DOB"); }
        }
        /// <summary>
        /// For NHS
        /// </summary>
        private string _nhs;
        public string NHS
        {
            get { return _nhs; }
            set { _nhs = value; OnPropertyChanged("NHS"); }
        }
        /// <summary>
        /// For Female select option
        /// </summary>
        private bool _isFemaleSelected;
        public bool IsFemaleSelected
        {
            get { return _isFemaleSelected; }
            set { _isFemaleSelected = value; OnPropertyChanged("IsFemaleSelected"); }
        }
        /// <summary>
        /// For Male select option
        /// </summary>
        private bool _isMaleSelected;
        public bool IsMaleSelected
        {
            get { return _isMaleSelected; }
            set { _isMaleSelected = value; OnPropertyChanged("IsMaleSelected"); }
        }
        /// <summary>
        /// For Mobile No
        /// </summary>
        private string _mobileNo;
        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; OnPropertyChanged("MobileNo"); }
        }
        /// <summary>
        /// Show validation message for mobile Phone control
        /// </summary>
        private string _mobilePhoneMessage;
        public string MobilePhoneMessage
        {
            get { return _mobilePhoneMessage; }
            set { _mobilePhoneMessage = value; OnPropertyChanged("MobilePhoneMessage"); }
        }
        /// <summary>
        /// Show the Mobile Phone validator
        /// </summary>
        private Visibility _isMobilePhoneValidatorVisible;
        public Visibility IsMobilePhoneValidatorVisible
        {
            get { return _isMobilePhoneValidatorVisible; }
            set { _isMobilePhoneValidatorVisible = value; OnPropertyChanged("IsMobilePhoneValidatorVisible"); }
        }
        /// <summary>
        /// Show validation border over Mobile Phone control
        /// </summary
        private Thickness _mobilePhoneBorder;
        public Thickness MobilePhoneBorder
        {
            get { return _mobilePhoneBorder; }
            set { _mobilePhoneBorder = value; OnPropertyChanged("MobilePhoneBorder"); }
        }
        /// <summary>
        /// For email id
        /// </summary>
        private string _emailId;
        public string EmailId
        {
            get { return _emailId; }
            set { _emailId = value; OnPropertyChanged("EmailId"); }
        }
        /// <summary>
        /// Select/Unselect Terms and Conditions
        /// </summary>
        private bool _checkedorNot;
        public bool CheckedorNot
        {
            get { return _checkedorNot; }
            set { _checkedorNot = value; OnPropertyChanged("CheckedorNot"); }
        }
        /// <summary>
        /// Show Terms and Conditions validation message
        /// </summary>
        private string _tcMessage;
        public string TCMessage
        {
            get { return _tcMessage; }
            set { _tcMessage = value; OnPropertyChanged("TCMessage"); }
        }
        /// <summary>
        /// Show TC validator
        /// </summary>
        private Visibility _isTCValidatorVisible;
        public Visibility IsTCValidatorVisible
        {
            get { return _isTCValidatorVisible; }
            set { _isTCValidatorVisible = value; OnPropertyChanged("IsTCValidatorVisible"); }
        }
        /// <summary>
        /// Show validation border over TC control
        /// </summary>
        private Thickness _tcBorder;
        public Thickness TCBorder
        {
            get { return _tcBorder; }
            set { _tcBorder = value; OnPropertyChanged("TCBorder"); }
        }
        /// <summary>
        /// For Select Surgery
        /// </summary>
        private string _buttonValue;
        public  string ButtonValue
        {
            get { return _buttonValue; }
            set { _buttonValue = value; OnPropertyChanged("ButtonValue"); }
        }
        /// <summary>
        /// Property to set Navigation Page
        /// </summary>
        private RelayCommand _surgeryPage;
        public RelayCommand SurgeryPage
        {
            get
            {
                if (_surgeryPage == null)
                {
                    _surgeryPage = new RelayCommand(NavigateToSurgeryPage);
                    _surgeryPage.Enabled = true;
                }
                return _surgeryPage;
            }
            set { _surgeryPage = value; }
        }  
        /// <summary>
        /// Property to set Navigation Page
        /// </summary>
        private RelayCommand _navigateTo;
        public RelayCommand NavigateTo
        {
            get
            {
                if (_navigateTo == null)
                {
                    _navigateTo = new RelayCommand(NavigateToTermsandCondition);
                    _navigateTo.Enabled = true;
                }

                return _navigateTo;
            }
            set { _navigateTo = value; }
        }

        /// <summary>
        /// Property to set Navigation Page
        /// </summary>
        private RelayCommand _updateChanges;
        public RelayCommand UpdateChanges
        {
            get
            {
                if (_updateChanges == null)
                {
                    _updateChanges = new RelayCommand(SaveChanges);
                    _updateChanges.Enabled = true;
                }

                return _updateChanges;
            }
            set { _updateChanges = value; }
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

                    _OkCommand = new RelayCommand(PopupOk);
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
        /// Property for OK button of successpopup 
        /// </summary>
        private RelayCommand _successokCommand;

        public RelayCommand SuccessCommand
        {
            get
            {
                if (_successokCommand == null)
                {

                    _successokCommand = new RelayCommand(SuccessOk);
                    _successokCommand.Enabled = true;


                }
                return _successokCommand;
            }
            set
            {
                _successokCommand = value;
            }
        }

        
        /// <summary>
        /// Property to show and hide successpopup 
        /// </summary>
        private string _isSuccessPopupOpen;

        public string IsSuccessPopupOpen
        {
            get { return _isSuccessPopupOpen; }
            set { _isSuccessPopupOpen = value; OnPropertyChanged("IsSuccessPopupOpen"); }
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
        /// Set successpopup text
        /// </summary>
        private string _successPopupText;

        public string SuccessPopupText
        {
            get { return _successPopupText; }
            set { _successPopupText = value; OnPropertyChanged("SuccessPopupText"); }
        }

        /// <summary>
        /// Set popup text
        /// </summary>
        private string _popuptext;

        public string PopupText
        {
            get { return _popuptext; }
            set { _popuptext = value; OnPropertyChanged("PopupText"); }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Click ok button of success popup
        /// </summary>
        private void SuccessOk()
        {
            IsSuccessPopupOpen = "false";
            if (Utilities.IsConnectedToNetwork())
            {
                PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                frame.Navigate(new Uri(PageURL.navigateToHomePanoramaURL, UriKind.Relative));
            }
            else
            {
                IsPopupOpen = "true";
                PopupText = "No connectivity.";
            }
        }

        /// <summary>
        /// Click ok button of Popup
        /// </summary>
        private void PopupOk()
        {
            IsPopupOpen = "false";
        }
        /// <summary>
        /// Method to Navigate to Surgery Page
        /// </summary>
        private void NavigateToSurgeryPage()
        {
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;
            if (Utilities.IsConnectedToNetwork())
            {
                success = frame.Navigate(new Uri(PageURL.navigateToSelectSurgeryURL, UriKind.Relative));
            }
            else
            {
                IsPopupOpen = "true";
                PopupText = "No connectivity.";
            }

        }
        /// <summary>
        /// Method to Navigate to Terms and Condition Page
        /// </summary>
        private void NavigateToTermsandCondition()
        {
            PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            bool success = false;
            if (Utilities.IsConnectedToNetwork())
            {
                success = frame.Navigate(new Uri(PageURL.navigateToTermsandConditionURL, UriKind.Relative));
            }
            else
            {
                IsPopupOpen = "true";
                PopupText = "No connectivity.";
            }
        }
        /// <summary>
        /// Save data
        /// </summary>
        private void SaveChanges()
        {
           
            bool success = false;

            bool IsDataValid = false;
            IsDataValid =  IsValidData();
            if (Utilities.IsConnectedToNetwork())
            {
                if (IsDataValid)
                {
                    objydtcModel = new YourDetailswithTCModel(this);
                    //  success = frame.Navigate(new Uri(PageURL.navigateToHomePanoramaURL, UriKind.Relative));
                }
            }
            else
            {
                IsPopupOpen = "true";
                PopupText = "No connectivity.";
            }          
        }
        /// <summary>
        /// Validate Controls
        /// </summary>
        /// <returns></returns>
        private bool IsValidData()
        {
            bool AddressLine1HasValue;
            bool AddressLine2HasValue;
            bool AddressLine3HasValue;
            bool PostCodeHasValue;
            bool MobileNoHasValue;
            bool TCHasValue;
            if (string.IsNullOrEmpty(AddressLine1) || string.IsNullOrWhiteSpace(AddressLine1))
            {
                IsAddressLine1ValidatorVisible = Visibility.Visible;
                AddresLine1Border = new Thickness(1.5);
                AddressLine1Message = "Address Line 1 required.";
                AddressLine1HasValue = false;
            }
            else
            {
                IsAddressLine1ValidatorVisible = Visibility.Collapsed;
                AddresLine1Border = new Thickness(0);
                AddressLine1HasValue = true;
            }

            if (string.IsNullOrEmpty(AddressLine2) || string.IsNullOrWhiteSpace(AddressLine2))
            {
                IsAddressLine2ValidatorVisible = Visibility.Visible;
                AddresLine2Border = new Thickness(1.5);
                AddressLine2Message = "Address Line 2 required.";
                AddressLine2HasValue = false;
            }
            else
            {
                IsAddressLine2ValidatorVisible = Visibility.Collapsed;
                AddresLine2Border = new Thickness(0);
                AddressLine2HasValue = true;
            }
            if (PickerSelectedIndex==0)
            {
                IsAddressLine3ValidatorVisible = Visibility.Visible;
                AddresLine3Border = new Thickness(1.5);
                AddressLine3Message = "Please select a country.";
                AddressLine3HasValue = false;
            }
            else
            {
                IsAddressLine3ValidatorVisible = Visibility.Collapsed;
                AddresLine3Border = new Thickness(0);
                AddressLine3HasValue = true;
            }
            if (string.IsNullOrEmpty(PostCode) || string.IsNullOrWhiteSpace(PostCode))
            {
                IsPostCodeValidatorVisible = Visibility.Visible;
                PostCodeBorder = new Thickness(1.5);
                PostCodeMessage = "Post Code required.";
                PostCodeHasValue = false;
            }
            else
            {
                bool isPostCodeValid = Regex.IsMatch(PostCode, @"((([A-PR-UWYZ][0-9][0-9]?)|(([A-PR-UWYZ][A-HK-Y][0-9][0-9]?)|(([A-PR-UWYZ][0-9][A-HJKSTUW])|([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRV-Y])))) ?[0-9][ABD-HJLNP-UW-Z]{2})", RegexOptions.IgnoreCase);
                if (isPostCodeValid)
                {
                    IsPostCodeValidatorVisible = Visibility.Collapsed;
                    PostCodeBorder = new Thickness(0);
                    PostCodeHasValue = true;
                }
                else
                {
                    IsPostCodeValidatorVisible = Visibility.Visible;
                    PostCodeBorder = new Thickness(1.5);
                    PostCodeMessage = "Invalid Post Code.";
                    PostCodeHasValue = false;
                }
            }

            if (string.IsNullOrEmpty(MobileNo) || string.IsNullOrWhiteSpace(MobileNo))
            {
                IsMobilePhoneValidatorVisible = Visibility.Visible;
                MobilePhoneBorder = new Thickness(1.5);
                MobilePhoneMessage = "Mobile Number required.";
                MobileNoHasValue = false;
            }
            else
            {
                //if (MobileNo.Length<10)
                //{
                //    IsMobilePhoneValidatorVisible = Visibility.Visible;
                //    MobilePhoneBorder = new Thickness(1.5);
                //    MobilePhoneMessage = "Minimum 10 digits required.";
                //    MobileNoHasValue = false;
                //}
                //else
                //{
                bool isDigitsOnly = Regex.IsMatch(MobileNo, "^[0-9]*$", RegexOptions.IgnorePatternWhitespace);
                if (isDigitsOnly)
                {
                    IsMobilePhoneValidatorVisible = Visibility.Collapsed;
                    MobilePhoneBorder = new Thickness(0);
                    MobileNoHasValue = true;
                }
                else
                {
                    IsMobilePhoneValidatorVisible = Visibility.Visible;
                    MobilePhoneBorder = new Thickness(1.5);
                    MobilePhoneMessage = "Only digits allowed.";
                    MobileNoHasValue = false;
                }
                //}
                
            }
            if (!CheckedorNot)
            {
                IsTCValidatorVisible = Visibility.Visible;
                TCBorder = new Thickness(1.5);
                TCMessage = "Please read and accept terms and conditions.";
                TCHasValue = false;
            }
            else
            {
                IsTCValidatorVisible = Visibility.Collapsed;
                TCBorder = new Thickness(0);
                TCHasValue = true;
            }


            if ((AddressLine1HasValue) && (AddressLine2HasValue) && (AddressLine3HasValue)&&(PostCodeHasValue) && (MobileNoHasValue) && (TCHasValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
        #endregion

        
    }
}

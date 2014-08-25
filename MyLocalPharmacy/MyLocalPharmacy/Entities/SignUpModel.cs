using MyLocalPharmacy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Entities;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MyLocalPharmacy.Model
{
    public class SignUpModel
    {
        public SignUpViewModel objSignUpViewModel;
      
        public SignUpModel(SignUpViewModel signUpViewModel)
        {
            objSignUpViewModel = signUpViewModel;
            CallGetPharmacyInformationWebService();
        }

        public SignUpModel(SignUpViewModel loginViewModel,string forlogin)
        {
            objSignUpViewModel = loginViewModel;
            if (forlogin=="Loginscreen")
            {
                LoginPharmacyInformationWebService();
            }
            else
            {
                ResetPinWebService();
            }
           
        }

      /* public SignUpModel(SignUpViewModel loginViewModel, int forpinreset)
        {
            objSignUpViewModel = loginViewModel;
            ResetPinWebService();
        }*/

        private  void ResetPinWebService()
        {
            string apiUrl = RxConstants.sendResetPinCode;
            SendResetPinCodeRequest objInputParam = new SendResetPinCodeRequest
            {
                mail = objSignUpViewModel.LoginEmail
            };

            WebClient resetpinswebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);
           var json = JsonHelper.Serialize(objInputParam);
        //   var result = await RequestData(uri.ToString(),json);

           resetpinswebservicecall.Headers["Content-type"] = "application/json";
           resetpinswebservicecall.UploadStringCompleted += resetpinswebservicecall_UploadStringCompleted;

           resetpinswebservicecall.UploadStringAsync(uri, "POST", json);
        }

        public async Task<string> RequestData(string url,string data)
        {
            var tcs = new TaskCompletionSource<string>();
            var uri = new UriBuilder(url);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.UploadStringCompleted += resetpinswebservicecall_UploadStringCompleted;
            webClient.UploadStringAsync(new Uri(url),"POST", data);
            return await tcs.Task;

        }

        private  void resetpinswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            SendResetPinCodeResponse objresetpincoderesponse = new SendResetPinCodeResponse();
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objresetpincoderesponse =  Utils.JsonHelper.Deserialize<SendResetPinCodeResponse>(response);
            
                if (objresetpincoderesponse.status == 0 )
                {
                    PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                    frame.Navigate(new Uri(PageURL.navigateToResetPinURL, UriKind.Relative));
                }
                else if (objresetpincoderesponse.status == 310)
                {
                    objSignUpViewModel.IsLoginEmailValidatorVisible = Visibility.Visible;
                    objSignUpViewModel.EmailValidationMessage = "No such user.";
                    //MessageBox.Show("No such user", "Invalid User", MessageBoxButton.OK);
                }
               
            }
        }

        private void LoginPharmacyInformationWebService()
        {
            //{"mail":"abhijithg@qburst.com", "pin":"0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c", "pharmacyid":"MGS001"}
            string apiUrl = RxConstants.getUserDetails;
            LoginParameters objLoginparameters = new LoginParameters
            {
                Mail=objSignUpViewModel.LoginEmail,
                Pharmacyid=objSignUpViewModel.LoginPharmacyID.ToUpper(),
                Pin = App.HashPIN

            };

            WebClient userdetailswebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

            var json = JsonHelper.Serialize(objLoginparameters);
            userdetailswebservicecall.Headers["Content-type"] = "application/json";
            userdetailswebservicecall.UploadStringCompleted += userdetailswebservicecall_UploadStringCompleted;

            userdetailswebservicecall.UploadStringAsync(uri, "POST", json);
        }

        private void userdetailswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            LoginResponse objlgresponse = new LoginResponse();
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objlgresponse = Utils.JsonHelper.Deserialize<LoginResponse>(response);
                if (objlgresponse.status == 0)
                {
                    App.Objlgresponse = objlgresponse;                                      
                    PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                    frame.Navigate(new Uri(PageURL.navigateToYourDetailswithTCURL, UriKind.Relative));
                }
            }

        }

        public void CallGetPharmacyInformationWebService()
        {
           
            string apiUrl = RxConstants.getPharmacyInformations;
           // {"pharmacyid":"MGS001", "deviceid":"jnwub7628fs", "model":"Nexus 7", "os":"Android", "branding_hash":"kheyjfgyagfysg", "advert_hash":"uehu921jdnkg", "drugs_hash":"uhuh89239djg"}

            GetPharmacyInformationRequest objInputParameters = new GetPharmacyInformationRequest
            {
                Pharmacyid =objSignUpViewModel.SignUpPharmacyID.ToUpper(),// "MGS001",
                Deviceid = "",
                Model = "",
                Os = "",
                Branding_hash = "",
                Advert_hash = "",
                Drugs_hash = ""
            };
            //LoginParameters objLoginParameters = new LoginParameters
            //{
            //     Mail = "abhijithg@qburst.com",
            //    Pin = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c",
            //    Pharmacyid = "MGS001"
               
            //};


            WebClient pharmacyinfowebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

            var json = JsonHelper.Serialize(objInputParameters);
            pharmacyinfowebservicecall.Headers["Content-type"] = "application/json";
            pharmacyinfowebservicecall.UploadStringCompleted += pharmacyinfowebservicecall_UploadStringCompleted;

            pharmacyinfowebservicecall.UploadStringAsync(uri, "POST", json);
        }
        void pharmacyinfowebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            GetPharmacyInformationResponse objLoginResponse = null;
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objLoginResponse = Utils.JsonHelper.Deserialize<GetPharmacyInformationResponse>(response);
                if (objLoginResponse.payload != null)
                {
                    objSignUpViewModel.PharmacyName = objLoginResponse.payload.branding_data.pharmacy_name;
                    objSignUpViewModel.AddressLine1 = objLoginResponse.payload.branding_data.address1;
                    objSignUpViewModel.AddressLine2 = objLoginResponse.payload.branding_data.address2;
                    objSignUpViewModel.PinCode = objLoginResponse.payload.branding_data.postcode;
                    objSignUpViewModel.IsPharmacyDetailsVisible = Visibility.Visible;
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                }
            }
        }

        #region Login

        #endregion
    }
}

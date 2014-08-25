using Microsoft.Phone.Controls;
using MyLocalPharmacy.Entities;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLocalPharmacy.Model
{
   public class YourDetailswithTCModel
    {
       public YourDetailswithTCViewModel objYourDetTCViewModel;
       /// <summary>
       /// Constructor
       /// </summary>
       /// <param name="objYourDetTCVM"></param>
       public YourDetailswithTCModel(YourDetailswithTCViewModel objYourDetTCVM)
        {
            objYourDetTCViewModel = objYourDetTCVM;
            CallSendUserDetailsWebService();
        }
       /// <summary>
       /// Call web service for senduserdetails
       /// </summary>
       private void CallSendUserDetailsWebService()
       {
           objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Visible;
              //         {
              //"pharmacyid": "MGS001",
              //"model":"kindle",
              //"os":"Adroid",
              //"fullname":"John Doe",
              //"nhs":"123456789",
              //"birthdate":"1/1/2012",
              //"address1":"asdqwe",
              //"address2":"zxcvcvb",
              //"postcode":"WD16AT",
              //"phone":"48694914628",
              //"mail":"asd@qwe.com",
              //"sex":"1",
              //"pin":"123456",
              //"country":"England",
              //"surgery":{
              //  "name":"asd",
              //  "address":"qwe"
              //}
            //}

           string apiUrl = RxConstants.sendUserDetails;
           string gender = "0";
           if (objYourDetTCViewModel.IsMaleSelected)
           {
               gender = "1";
           }
           else
           {
               gender = "0";
           }

           SendUserDetailsRequest objInputParameters = new SendUserDetailsRequest
           {
               pharmacyid = App.LoginPharId.ToUpper(),// "MGS001",
               model = "",
               os = "",
               fullname = objYourDetTCViewModel.FirstName+" "+objYourDetTCViewModel.LastName,
               nhs = objYourDetTCViewModel.NHS,
               birthdate = objYourDetTCViewModel.DOB,
               address1 = objYourDetTCViewModel.AddressLine1,
               address2=objYourDetTCViewModel.AddressLine2,
               postcode=objYourDetTCViewModel.PostCode,
               phone=objYourDetTCViewModel.MobileNo,
               mail=objYourDetTCViewModel.EmailId,
               sex = gender,
               pin=App.HashPIN,
               country = objYourDetTCViewModel.SelectedCountry,
               surgery=null
           };
           WebClient sendUserDetailswebservicecall = new WebClient();
           var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

           var json = JsonHelper.Serialize(objInputParameters);
           sendUserDetailswebservicecall.Headers["Content-type"] = "application/json";
           sendUserDetailswebservicecall.UploadStringCompleted += sendUserDetailswebservicecall_UploadStringCompleted;

           sendUserDetailswebservicecall.UploadStringAsync(uri, "POST", json);
       }
        /// <summary>
        /// Get Response from senduserdetails web service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void sendUserDetailswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
       {
           SendUserDetailsResponse objSendUserDetailsResponse = null;
           if (e.Result != null)
           {
               var response = e.Result.ToString();
               objSendUserDetailsResponse = Utils.JsonHelper.Deserialize<SendUserDetailsResponse>(response);
               if (objSendUserDetailsResponse.status==0)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsSuccessPopupOpen = "true";
                   objYourDetTCViewModel.SuccessPopupText = objSendUserDetailsResponse.message;// "Details Updated Successfully.";
                  // MessageBox.Show("Details Updated Successfully.", "Successfull", MessageBoxButton.OK);
                  
               }
               else if (objSendUserDetailsResponse.status == 100)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "At least one of required input argument is not found.";
                  // MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 301)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "Incorrect PIN provided.";
                   //MessageBox.Show("Incorrect PIN provided.", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 307)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "No such pharmacy.";
                   //MessageBox.Show("No such pharmacy.", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 314)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "Patient has no accepted nomination.";
                  // MessageBox.Show("Patient has no accepted nomination.", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 319)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "Nomination is disabled.";
                  // MessageBox.Show("Nomination is disabled.", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 321)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "You have to get approval for pharmacy " + App.LoginPharmacyname + ".";
                  // MessageBox.Show("You have to get approval for pharmacy " + App.LoginPharmacyname+".", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 308)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "Patient has not nominated this pharmacy.";
                   //MessageBox.Show("Patient has not nominated this pharmacy.", "Error", MessageBoxButton.OK);
               }
               else if (objSendUserDetailsResponse.status == 320)
               {
                   objYourDetTCViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetTCViewModel.IsPopupOpen = "true";
                   objYourDetTCViewModel.PopupText = objSendUserDetailsResponse.message;// "Your nomination for " + App.LoginPharmacyname + " has to be approved by pharmacist.";
                  // MessageBox.Show("Your nomination for " + App.LoginPharmacyname + " has to be approved by pharmacist.", "Error", MessageBoxButton.OK);
               }
               
               
           }
       }

    }
}

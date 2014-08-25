using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MyLocalPharmacy.ViewModel;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Entities;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
namespace MyLocalPharmacy.Model
{
  public  class YourDetailsLoginModel
    {
       public YourDetailsLoginViewModel objYourDetlginViewModel;
       string verifyBy = "mail";
      /// <summary>
      /// Constructor
      /// </summary>
      /// <param name="objYourDetloginVM"></param>
       public YourDetailsLoginModel(YourDetailsLoginViewModel objYourDetloginVM)
        {
            
            objYourDetlginViewModel = objYourDetloginVM;
            CallSendNominationWebService();
        }
      /// <summary>
      /// Call web service for send nomination
      /// </summary>
       private void CallSendNominationWebService()
       {
           objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Visible;
           
           
                //{
                //  "pharmacyid": "MGS001",
                //  "deviceid": "hhe7f346cbb38c01fd7f949d97a605884ff50d611afabbf8ead",
                //  "model":"kindle",
                //  "os":"Adroid",
                //  "pushid":"APA91bGmnxKHH8txvTXfLlkm0PC_gY",
                //  "fullname":"John Doe",
                //  "nhs":"123456789",
                //  "birthdate":"1/1/2012",
                //  "address1":"asdqwe",
                //  "address2":"zxcvcvb",
                //  "postcode":"WD16AT",
                //  "phone":"48694914628",
                //  "mail":"zxc@qwe.com",
                //  "sex":"1",
                //  "pin":"123456",
                //  "country":"England",
                //  "mode":"new",
                //  "verifyby":"mail",
                //  "surgery":{
                //    "name":"asd",
                //    "address":"qwe"
                //  }
                //}

           string apiUrl = RxConstants.sendNomination;
           string gender = "0";
           if (objYourDetlginViewModel.IsMaleSelected)
           {
               gender = "1";
           }
           else
           {
               gender = "0";
           }

         
           if (objYourDetlginViewModel.IsMailSelected)
           {
               verifyBy = "mail";
           }
           else
           {
               verifyBy = "sms";
           }

           string deviceUniqueID = string.Empty;
           object deviceID;
           if (DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out deviceID))
           {
               deviceUniqueID = deviceID.ToString();
           }

           string deviceName = string.Empty;
           object devicename;
           if (DeviceExtendedProperties.TryGetValue("DeviceName", out devicename))
           {
               deviceName = devicename.ToString();
           }
           

          // App.LoginPharId = "MGS001";
           //0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c
              SendNominationRequest objInputParameters = new SendNominationRequest
              {
                  pharmacyid = App.SignUpPharId.ToUpper(),// "MGS001",
                  deviceid = deviceUniqueID,
                  model = DeviceModel,
                  os = "Windows Phone" + Environment.OSVersion.Version.ToString(),
                  pushid = "",
                  fullname = objYourDetlginViewModel.FirstName + " " + objYourDetlginViewModel.LastName,
                  nhs = objYourDetlginViewModel.NHS,
                  birthdate = objYourDetlginViewModel.DOB.ToString("dd/MM/yyyy"),
                  address1 = objYourDetlginViewModel.AddressLine1,
                  address2 = objYourDetlginViewModel.AddressLine2,
                  postcode = objYourDetlginViewModel.PostCode,
                  phone = objYourDetlginViewModel.MobileNo,
                  mail = objYourDetlginViewModel.EmailId,
                  sex = gender,
                  pin = App.HashPIN,
                  country = objYourDetlginViewModel.SelectedCountry,
                  mode = "new",
                  verifyby = verifyBy,
                  surgery = new SendNominationRequestSurgery { name = "", address="" }
              };

           WebClient sendNominationswebservicecall = new WebClient();
           var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

           var json = JsonHelper.Serialize(objInputParameters);
           sendNominationswebservicecall.Headers["Content-type"] = "application/json";
           sendNominationswebservicecall.UploadStringCompleted += sendNominationswebservicecall_UploadStringCompleted;

           sendNominationswebservicecall.UploadStringAsync(uri, "POST", json);
       }
       public static string DeviceModel
       {
           get
           {
               string manufacturer = DeviceStatus.DeviceManufacturer;
               string model = string.Empty;
               if (manufacturer.Equals("NOKIA"))
               {
                   model = manufacturer + " ";
                   string name = DeviceStatus.DeviceName.Substring(0, 6);
                   switch (name)
                   {
                       case "RM-846":
                           model += "Lumia 620";
                           break;
                       case "RM-878":
                           model += "Lumia 810";
                           break;
                       case "RM-824":
                       case "RM-825":
                       case "RM-826":
                           model += "Lumia 820";
                           break;
                       case "RM-845":
                           model += "Lumia 822";
                           break;
                       case "RM-820":
                       case "RM-821":
                       case "RM-822":
                           model += "Lumia 920";
                           break;
                       case "RM-867":
                           model += "Lumia 920T";
                           break;
                   }
               }
               else if (manufacturer.Equals("HTC"))
               {
                   string[] partModel = DeviceStatus.DeviceName.Split(' ');
                   model = manufacturer + " " + partModel[2];
               }
               else if (manufacturer.Equals("Huawei"))
               {
                   //Huawei Ascend W1 (untested)
                   model = DeviceStatus.DeviceName;
               }
               else if (manufacturer.Equals("Samsung"))
               {
                   //Samsung Ativ S, Samsung Ativ Odyssey (untested)
                   model = DeviceStatus.DeviceName;
               }
               return model;
           }
       }
      /// <summary>
      /// Get response from the web service
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
       private void sendNominationswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
       {
           SendNominationResponse objSendNominationResponse = null;
           if (e.Result != null)
           {
               var response = e.Result.ToString();
               objSendNominationResponse = Utils.JsonHelper.Deserialize<SendNominationResponse>(response);
               if (objSendNominationResponse.status == 0)
               {
                  App.YourDetailsLoginEmail= objYourDetlginViewModel.EmailId;
                  objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                  objYourDetlginViewModel.IsSuccessPopupOpen = "true";
                  objYourDetlginViewModel.SuccessPopupText = objSendNominationResponse.message;// "Patient created.";
                  // MessageBox.Show(objSendNominationResponse.message, "Successfull", MessageBoxButton.OK);
                   //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                   //if (verifyBy=="mail")
                   //{
                   //    frame.Navigate(new Uri(PageURL.navigateToVerificationByEmailURL, UriKind.Relative));
                   //}
                   //else
                   //{
                   //    frame.Navigate(new Uri(PageURL.navigateToVerificationBySMSURL, UriKind.Relative));
                   //}
                              
               }
               else if (objSendNominationResponse.status == 100)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "At least one of required input argument is not found.";
                   //MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
               }             
               else if (objSendNominationResponse.status == 105)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "There is no branch with provided branch ID.";
                   //MessageBox.Show("There is no branch with provided branch ID.", "Error", MessageBoxButton.OK);
               }
               else if (objSendNominationResponse.status == 106)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "Chosen pharmacy has been removed. For further information please contact pharmacy officials.";
                   //MessageBox.Show("Chosen pharmacy has been removed. For further information please contact pharmacy officials.", "Error", MessageBoxButton.OK);
               }
               else if (objSendNominationResponse.status == 301)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "Incorrect PIN provided.";
                   //MessageBox.Show("Incorrect PIN provided.", "Error", MessageBoxButton.OK);
               }
               else if (objSendNominationResponse.status == 302)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "User with this email address is already registered.";
                   //MessageBox.Show("User with this email address is already registered.", "Error", MessageBoxButton.OK);
               }
               else if (objSendNominationResponse.status == 311)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "Error during registration.";
                   //MessageBox.Show("Error during registration.", "Error", MessageBoxButton.OK);
               }
               else if (objSendNominationResponse.status == 322)
               {
                   objYourDetlginViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                   objYourDetlginViewModel.IsPopupOpen = "true";
                   objYourDetlginViewModel.PopupText = objSendNominationResponse.message;// "You have to make some changes before submitting.";
                   //MessageBox.Show("You have to make some changes before submitting.", "Error", MessageBoxButton.OK);
               }              
           }
       }
       
    }
}

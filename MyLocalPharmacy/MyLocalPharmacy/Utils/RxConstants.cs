using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Utils
{
   public sealed class RxConstants
    {

        #region Webservices
        public const string getPharmacyInformations = "https://rxmobile.rxsystems.org.uk/1.0/getPharmacyInformations/";
        public const string getAdvert = "https://rxmobile.rxsystems.org.uk/1.0/getAdvert/";
        public const string getUserDetails = "https://rxmobile.rxsystems.org.uk/1.0/getUserDetails/";
        public const string sendNomination = "https://rxmobile.rxsystems.org.uk/1.0/sendNomination/";
        public const string changePin = "https://rxmobile.rxsystems.org.uk/1.0/changePin/";
        public const string getAllOrders = "https://rxmobile.rxsystems.org.uk/1.0/getAllOrders/";
        public const string sendOrder = "https://rxmobile.rxsystems.org.uk/1.0/sendOrder/";
        public const string sendResetPinCode = "https://rxmobile.rxsystems.org.uk/1.0/sendResetPinCode/";
        public const string resetPin = "https://rxmobile.rxsystems.org.uk/1.0/resetPin/";
        public const string removeOrder = "https://rxmobile.rxsystems.org.uk/1.0/removeOrder/";
        public const string updatePushNotificationsId = "https://rxmobile.rxsystems.org.uk/1.0/updatePushNotificationsId/";
        public const string sendUserDetails = "https://rxmobile.rxsystems.org.uk/1.0/sendUserDetails/";
        public const string resendConfirmationCodes = "https://rxmobile.rxsystems.org.uk/1.0/resendConfirmationCodes/";
        #endregion

        #region Setup Screen Navigations
        public const string termsandConditionslink = "http://securepharm.co.uk/content/documentation/rxs-mpa-customer-licence_final_6-january-2014_blms_v-1-4/";
        public const string myLocalPharmacySupport = "http://www.mylocalpharmacyapp.co.uk"; 
        #endregion

        #region NHS Services
        public const string nhsWales = "http://www.wales.nhs.uk/ourservices/directory";
        public const string nhsScotland = "http://www.nhs24.com/FindLocal";
        public const string nhsNorthernIreland = "http://servicefinder.hscni.net/"; 
        #endregion

    }
}

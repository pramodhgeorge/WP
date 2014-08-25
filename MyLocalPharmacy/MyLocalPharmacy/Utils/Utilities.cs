using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace MyLocalPharmacy.Utils
{
    public static class Utilities
    {
             
        #region NetworkConnectivity
        public static bool IsConnectedToNetwork()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
        #endregion


        #region SHA256 Encoder
        public static string GetSHA256(string text)
        {
            //  UnicodeEncoding UE = new UnicodeEncoding();
            Encoding enc = Encoding.UTF8;
            byte[] hashValue;
            byte[] message = enc.GetBytes(text);

            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        } 
        #endregion

        #region String to Color Code
        public static SolidColorBrush GetColorFromHexa(string hexaColor)
        {
            //hexaColor = "#FF" + hexaColor;
            //hexaColor = "#FF1BA1E2";
            //hexaColor = "#FFadbbff";
            //hexaColor = "#adbbff"; 
            hexaColor = "#" + "FF" + hexaColor.Substring(1, hexaColor.Length - 1);
            return new SolidColorBrush(
                Color.FromArgb(
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16),
                    Convert.ToByte(hexaColor.Substring(7, 2), 16)
                )
            );
        }
        #endregion
    }
}

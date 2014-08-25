using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;
using MyLocalPharmacy.Entities;


namespace MyLocalPharmacy.Utils
{
    public class IsoStoreHelper
    {
        public static void SaveImage(BitmapImage imageUri,string imageName)
        {
            try
            {
                using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorage.FileExists(imageName))
                        isolatedStorage.DeleteFile(imageName);

                    IsolatedStorageFileStream fileStream = isolatedStorage.CreateFile(imageName);

                    WriteableBitmap wb = new WriteableBitmap(imageUri);
                    wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveTileImage(BitmapImage imageUri, string imageName)
        {
            try
            {
                using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorage.FileExists(imageName))
                        isolatedStorage.DeleteFile(imageName);

                    IsolatedStorageFileStream fileStream = isolatedStorage.CreateFile(imageName);

                    WriteableBitmap wb = new WriteableBitmap(imageUri);
                    wb.SaveJpeg(fileStream, 130, 202, 0, 85);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static BitmapImage GetImage(string imageUri) 
        {
            BitmapImage bi = new BitmapImage();
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(imageUri, FileMode.Open, FileAccess.Read))
                    {
                        bi.SetSource(fileStream);
                    }
                }
                return bi;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static BrandedConfiguration GetBrandInfo()
        {
            try
            {
                BrandedConfiguration brandedConfig = null;
                var document = XDocument.Load(@"Resources\BrandConfiguration.xml");
                foreach (XElement curElement in document.Descendants("BrandedAppConfiguration"))
                {
                    brandedConfig = new BrandedConfiguration()
                    {
                        OrganizationId = (string)(curElement.Element("organizationId")),
                        ConferenceCenterId = (string)(curElement.Element("conferenceCenterId"))
                    };
                }

                return brandedConfig;
            }
            catch (Exception ex)
            {
                throw ex;
            }
               
        }

        public static List<ConferenceDetails> GetBrandedConference()
        {
            List<ConferenceDetails> conferenceCollection = null;
            try
            {
                while (conferenceCollection == null)
                {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains("BrandedConferences"))
                    {
                        conferenceCollection = (List<ConferenceDetails>)(IsolatedStorageSettings.ApplicationSettings["BrandedConferences"]);
                        if (conferenceCollection.Count >= 0)
                        {
                            break;
                        }
                    }
                }

                return conferenceCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AttendeeDetails GetMyCheckInDetails()
        {
            AttendeeDetails attendee = null;
            try
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("MyCheckInDetails"))
                {
                    attendee = (AttendeeDetails)(IsolatedStorageSettings.ApplicationSettings["MyCheckInDetails"]);
                }
               
                return attendee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}

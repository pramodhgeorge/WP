using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyLocalPharmacy.Utils
{
    public class MultiResImageChooserUri
    {
        public Uri SearchBar   
        {
            get
            {
                switch (ResolutionHelper.CurrentResolution)
                {
                    case Resolutions.HD720p:
                        return new Uri("/Assets/Images/720p/SearchBar_720p.png", UriKind.Relative);
                    case Resolutions.WXGA:
                        return new Uri("/Assets/Images/WXGA/SearchBar_WXGA.png", UriKind.Relative);
                    case Resolutions.WVGA:
                        return new Uri("/Assets/Images/WVGA/SearchBar_WVGA.png", UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }

        public Uri Search  
        {
            get
            {
                switch (ResolutionHelper.CurrentResolution)
                {
                    case Resolutions.HD720p:
                        return new Uri("/Assets/Images/720p/Search_720p.png", UriKind.Relative);
                    case Resolutions.WXGA:
                        return new Uri("/Assets/Images/WXGA/Search_WXGA.png", UriKind.Relative);
                    case Resolutions.WVGA:
                        return new Uri("/Assets/Images/WVGA/Search_WVGA.png", UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }

        public Uri Background  
        {
            get
            {
                switch (ResolutionHelper.CurrentResolution)
                {
                    case Resolutions.HD720p:
                        return new Uri("/Assets/Images/720p/Background_720p.png", UriKind.Relative);
                    case Resolutions.WXGA:
                        return new Uri("/Assets/Images/WXGA/Background_WXGA.png", UriKind.Relative);
                    case Resolutions.WVGA:
                        return new Uri("/Assets/Images/WVGA/Background_WVGA.png", UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }

        public Uri HelpInfo   
        {
            get
            {
                switch (ResolutionHelper.CurrentResolution)
                {
                    case Resolutions.HD720p:
                        return new Uri("/Assets/Images/720p/HelpInfo_720p.png", UriKind.Relative);
                    case Resolutions.WXGA:
                        return new Uri("/Assets/Images/WXGA/HelpInfo_WXGA.png", UriKind.Relative);
                    case Resolutions.WVGA:
                        return new Uri("/Assets/Images/WVGA/HelpInfo_WVGA.png", UriKind.Relative);
                    default:
                        throw new InvalidOperationException("Unknown resolution type");
                }
            }
        }
    }
}

using Microsoft.Expression.Interactivity.Core;
using MyLocalPharmacy.Entities;
using MyLocalPharmacy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MyLocalPharmacy.ViewModel
{
    public class HomePanoramaViewModel:BaseViewModel
    {
       
        public HomePanoramaViewModel()
        {
            SampleCommand = new ActionCommand(
                    () =>
                    {
                        MessageBox.Show("Sample command.");
                    });
            if (App.Objbrandingesponse != null)
            {
                GetPharmacyInformationResponse objbrandinfo = new GetPharmacyInformationResponse();
                objbrandinfo = App.Objbrandingesponse;
                PrimaryColour = Utilities.GetColorFromHexa(App.Objbrandingesponse.payload.branding_data.appearance.primary_colour);
                SecondaryColour = Utilities.GetColorFromHexa(App.Objbrandingesponse.payload.branding_data.appearance.secondary_colour);
                FontColor = Utilities.GetColorFromHexa(App.Objbrandingesponse.payload.branding_data.appearance.font_colour);
            }
        }
        public ICommand SampleCommand { get; private set; }
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using MyLocalPharmacy.Entities;

namespace MyLocalPharmacy.View
{
    public partial class MapDenthist : PhoneApplicationPage
    {
       // int countTag = 0;

        public MapDenthist()
        {
            InitializeComponent();
            this.SetMap();
            //var location = new 
            //UserLocationMarker marker = (UserLocationMarker)this.FindName("UserLocationMarker");
            //marker.GeoCoordinate = MyMap.Center;
            //marker.GeoCoordinate = new GeoCoordinate(10.007929, 76.363585);

            //Pushpin pushpin = (Pushpin)this.FindName("MyPushpin");
            //pushpin.GeoCoordinate = new GeoCoordinate(10.007929, 76.363585);
            //ContentPanel.Children.Add(pushpin);
            
            
           
        }

        private void SetMap()
        {
            Map MyMap = new Map();
            MyMap.Center = new GeoCoordinate(10.007929, 76.363585);
            MyMap.ZoomLevel = 16;
            ContentPanel.Children.Add(MyMap);
            //Pushpin pushpin = new Pushpin();
            //MapLayer layer = new MapLayer();
            //MapOverlay overlay = new MapOverlay();
            //pushpin.GeoCoordinate = new GeoCoordinate(10.007929, 76.363585);
            //pushpin.Content = "My Location";
            //overlay.Content = pushpin;
            //overlay.GeoCoordinate = new GeoCoordinate(10.007929, 76.363585);
            //layer.Add(overlay);
            //MyMap.Layers.Add(layer);
            //ContentPanel.Children.Add(MyMap);

            GeoCoordinatesCollection coordinateCollection = new GeoCoordinatesCollection()
            {
                new GeoCoordinates (){ XCoordinate = 10.007929, YCoordinate = 76.363585, Data = "Tejomaya" },
                new GeoCoordinates (){ XCoordinate = 10.0079, YCoordinate = 76.36350, Data = "Leela" }
                
            };

            
            foreach (GeoCoordinates coordinate in coordinateCollection)
            {
                Pushpin pushpin = new Pushpin();
                
                pushpin.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(PushpinTap);
                
                
                //countTag = countTag + 1;
                //pushpin.Tag = ""+ ++countTag +"";
                //pushpin.Visibility = Visibility.Collapsed;
                //pushpin.Width = 25;
                //pushpin.Height = 100;
                    
                    //PushpinTap();

                MapLayer layer = new MapLayer();
                MapOverlay overlay = new MapOverlay();
                pushpin.GeoCoordinate = new GeoCoordinate(coordinate.XCoordinate, coordinate.YCoordinate);
                pushpin.Content = "";
                //pushpin.Content = ;
                pushpin.MinWidth = 50;
                pushpin.Tag = coordinate.Data;
                overlay.Content = pushpin;
                
                overlay.GeoCoordinate = new GeoCoordinate(coordinate.XCoordinate, coordinate.YCoordinate);
                layer.Add(overlay);
                MyMap.Layers.Add(layer);
                
            }
            //MessageBox.Show(""+ countTag + "");

        }

        private void PushpinTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string pushpinTag = (sender as Pushpin).Tag.ToString();
            (sender as Pushpin).Content = pushpinTag;
            //(sender as FrameworkElement).Visibility = Visibility.Visible;
            (sender as FrameworkElement).Width = 200;
            (sender as FrameworkElement).Height = 100;
            
            //this.Width = 40;
            //this.Height = 30;
            
            //MessageBox.Show(pushpinTag);
        }

        
       

        //private void MyPushpin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    MyPushpin.Visibility = System.Windows.Visibility.Visible;
        //    Pushpin pushpin = sender as Pushpin;
        //    MessageBox.Show(pushpin.Content.ToString());
        //}

        //private void PushpinLeela_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    MessageBox.Show("QBurst Technologies");
        //}
    }
}
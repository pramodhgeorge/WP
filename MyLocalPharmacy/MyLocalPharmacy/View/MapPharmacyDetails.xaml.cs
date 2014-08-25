using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Services;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.ViewModel;

namespace MyLocalPharmacy.View
{
    public partial class Page1 : PhoneApplicationPage
    {
        List<GeoCoordinate> myRouteCoordinates = new List<GeoCoordinate>();

        RouteQuery myRouteQuery;

        GeocodeQuery mygeocodeQuery;

        Geolocator MyGeolocator;

        Geoposition MyGeoPosition;

        //private bool isLoaded = false;

        public Page1()
        {
            InitializeComponent();
            this.DataContext = new MapPharmacyViewModel();
            /*
            Map MyMap = new Map();
            MyMap.Center = new GeoCoordinate(10.007929, 76.363585);
            MyMap.ZoomLevel = 18;
            MyMap.LandmarksEnabled = true;
            MyMap.PedestrianFeaturesEnabled = true;
            //MyMap.CartographicMode = ;
            ContentPanel.Children.Add(MyMap);
           // MapLayer  = new MapLayer();
           // MyMap.Layers.Add(maplayer);
            

            GetLocation();*/
            buttonDrivingDirections.IsEnabled = false;
            this.GetCurrentLocation();
        }

        private async void GetCurrentLocation()
        {

            MyGeolocator = new Geolocator();

            MyGeolocator.DesiredAccuracyInMeters = 20;

            MyGeoPosition = await MyGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10));

            myRouteCoordinates.Add(new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude));

            myMap.Center = new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude);
            myMap.ZoomLevel = 17;
            //isLoaded = true;
            MapLoaded();


        }

        private void MapLoaded()
        {
            buttonDrivingDirections.IsEnabled = true;
            progress.Visibility = Visibility.Collapsed;
        }
       
        void mygeocodeQuery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {

            if (e.Error == null)
            {

                myRouteQuery = new RouteQuery();

                myRouteCoordinates.Add(e.Result[0].GeoCoordinate);

                myRouteQuery.Waypoints = myRouteCoordinates;

                myRouteQuery.QueryCompleted += myRouteQuery_QueryCompleted;

                myRouteQuery.QueryAsync();

                mygeocodeQuery.Dispose();

            }

        }


        void myRouteQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {

            if (e.Error == null)
            {

                Route MyRoute = e.Result;

                MapRoute MyMapRoute = new MapRoute(MyRoute);

                myMap.AddRoute(MyMapRoute);

                foreach (RouteLeg leg in MyRoute.Legs)
                {

                    foreach (RouteManeuver maneuver in leg.Maneuvers)
                    {

                        textBoxDirections.Text += maneuver.InstructionText + Environment.NewLine;

                    }

                }

                myRouteQuery.Dispose();

            }

        }

        private void buttonDrivingDirections_Click(object sender, RoutedEventArgs e)
        {
            if (Utilities.IsConnectedToNetwork())
            {
                mygeocodeQuery = new GeocodeQuery();

                mygeocodeQuery.GeoCoordinate = new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude);

                mygeocodeQuery.SearchTerm = textBoxToAddress.Text;

                mygeocodeQuery.QueryCompleted += mygeocodeQuery_QueryCompleted;

                mygeocodeQuery.QueryAsync();
            }
            else
            {
                MessageBox.Show("No network found");
            }
        }

        

        /*async private void GetLocation()
        {

            var geolocator = new Geolocator();

            Geoposition position = await geolocator.GetGeopositionAsync();

            Geocoordinate coordinate = position.Coordinate;

            MessageBox.Show("Latitude = " + coordinate.Latitude + " Longitude = " + coordinate.Longitude);

        }*/

    }
}
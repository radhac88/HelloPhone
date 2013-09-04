using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace HelloPhone
{
    public partial class MapPage : PhoneApplicationPage
    {
        public MapPage()
        {
            InitializeComponent();
            map1.CredentialsProvider = new ApplicationIdCredentialsProvider("AonkIkqWjK4vVWhc5Cvm9ARnaTGsh-V3eOUrPK2fHxgGNKVgsyclGktq1RDQQXSV"); 
            Pushpin p = new Pushpin();
            p.Background = new SolidColorBrush(Colors.Yellow);
            p.Foreground = new SolidColorBrush(Colors.Black);
            p.Location = new GeoCoordinate(17.451356, 78.380735);
            p.Content = "You are here";
            map1.Children.Add(p);
            map1.SetView(new GeoCoordinate(10, 10, 20), 2);
        }

        private void zoomIn_click(object sender, EventArgs e)
        {
            map1.ZoomLevel++;
        }

        private void zoomOut_click(object sender, EventArgs e)
        {
            map1.ZoomLevel--;
        }

        private void chooseMyPosition_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChooseMyPosition.xaml", UriKind.Relative));
        }

        private void Aerial_click(object sender, EventArgs e)
        {
            map1.Mode = new AerialMode(true);
        }

        private void Road_click(object sender, EventArgs e)
        {
            map1.Mode = new RoadMode();
        }

        private void locateMe_click(object sender, EventArgs e)
        {
            Pushpin p = new Pushpin();
            p.Background = new SolidColorBrush(Colors.Yellow);
            p.Foreground = new SolidColorBrush(Colors.Black);
            p.Location = new GeoCoordinate(SharedInformation.myLatitude, SharedInformation.myLongitude);
            p.Content = "I'm here";
            map1.Children.Add(p);
            map1.SetView(new GeoCoordinate(SharedInformation.myLatitude, SharedInformation.myLongitude, 160), 2);
        }

        private void setPin_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PushpinProperties.xaml", UriKind.Relative));
        }

        private void addPin_click(object sender, EventArgs e)
        {
            Pushpin p = new Pushpin();
            p.Background = new SolidColorBrush(Colors.Blue);
            p.Foreground = new SolidColorBrush(Colors.White);
            p.Location = new GeoCoordinate(SharedInformation.pinLat, SharedInformation.pinLong);
            p.Content = SharedInformation.pinContent;
            map1.Children.Add(p);
        } 
    }

    public static class SharedInformation
    {
        //my location 
        public static double myLongitude;
        public static double myLatitude;

        //pushpin location and content 
        public static double pinLong;
        public static double pinLat;
        public static string pinContent;
    } 
}
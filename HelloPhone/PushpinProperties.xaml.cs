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

namespace HelloPhone
{
    public partial class PushpinProperties : PhoneApplicationPage
    {
        public PushpinProperties()
        {
            InitializeComponent();
        }

         private void addPin_Click(object sender, RoutedEventArgs e) 
        { 
            double longitude; 
            double latitude; 
            try 
            { 
                longitude = double.Parse(longitudeTB.Text.ToString()); 
                latitude = double.Parse(LatitudeTB.Text.ToString()); 
                SharedInformation.pinLong = longitude; 
                SharedInformation.pinLat = latitude; 
                SharedInformation.pinContent = textBox1.Text; 
 
                MessageBox.Show("Your Pushpin was successfully set!"); 
                NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative)); 
            } 
            catch (Exception exc) 
            { 
                MessageBox.Show("Please enter a valid location!" + exc.Message); 
            } 
        } 
 
        private void button2_Click(object sender, RoutedEventArgs e) 
        { 
            NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative)); 
        } 
    } 
}
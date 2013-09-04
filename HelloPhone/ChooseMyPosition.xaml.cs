﻿using System;
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
    public partial class ChooseMyPosition : PhoneApplicationPage
    {
        public ChooseMyPosition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //set position button 
            double longitude;
            double latitude;
            try
            {
                longitude = double.Parse(longitudeTB.Text.ToString());
                latitude = double.Parse(LatitudeTB.Text.ToString());
                SharedInformation.myLongitude = longitude;
                SharedInformation.myLatitude = latitude;

                MessageBox.Show("Your location was successfully set!");
                NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Please enter a valid location!" + exc.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //cancel button 
            NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative));
        }
    }
}

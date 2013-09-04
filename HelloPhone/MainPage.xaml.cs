using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;


namespace HelloPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
        }


        private void ClickMeButton_Click(object sender, RoutedEventArgs e)
        {
            //BannerTextBlock.Text = String.Empty;
            BannerTextBlock.Text = MessageTextBox.Text;
            MessageTextBox.Text = String.Empty;
            NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative));
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //textBlock1.Text = String.Empty;
            textBlock1.Text = textBox1.Text;
            textBox1.Text = String.Empty;
            NavigationService.Navigate(new Uri("/PuzzlePage.xaml", UriKind.Relative));
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            //WebBrowserTask wb = new WebBrowserTask();
            //string site = textBox2.Text;
            //wb.Uri = new Uri(site, UriKind.Absolute);
           //webBrowser1.Navigate(new Uri(site, UriKind.Absolute));
           // wb.Show();
           
        }
        

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void StartTransition()
        {
            //RollTransition rotatetransition = new RollTransition();
            RotateTransition rotatetransition = new RotateTransition();
            //rotatetransition.Mode = RotateTransitionMode.In90Clockwise;
            rotatetransition.Mode = RotateTransitionMode.In180Counterclockwise;           
          
            PhoneApplicationPage phoneApplicationPage =
            (PhoneApplicationPage)(((PhoneApplicationFrame)Application.Current.RootVisual)).Content;

            ITransition transition = rotatetransition.GetTransition(phoneApplicationPage);
            
            transition.Completed += delegate
            {
                transition.Stop();
            };
            transition.Begin();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            StartTransition();
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Image img = sender as Image;
            RotateTransform rotateTransform = img.RenderTransform as RotateTransform;

            // Create and define animation
            DoubleAnimation anima = new DoubleAnimation();
            anima.From = 0;
            anima.To = 360;
            anima.Duration = new Duration(TimeSpan.FromSeconds(0.5));

            // Set attached properties
            Storyboard.SetTarget(anima, rotateTransform);
            Storyboard.SetTargetProperty(anima, new PropertyPath(RotateTransform.AngleProperty));

            // Create storyboard, add animation, and fire it up!
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(anima);
            storyboard.Begin();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }

       

        
    }
}
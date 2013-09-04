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
using System.Threading;


namespace HelloPhone
{
    public partial class Page1 : PhoneApplicationPage
    {
        private static Random random;
        DateTime startTime;
        public Page1()
        {
            InitializeComponent();
            startTime = DateTime.Now;
            CompositionTarget.Rendering += OnCompositionTargetRendering;
            random = new Random();
            this.StartFallingSnowAnimation();
        }
        void OnCompositionTargetRendering(object sender, EventArgs args)
        {
            // Frame-based
            rotate1.Angle = (rotate1.Angle + 0.2) % 360;

            // Time-based
            TimeSpan elapsedTime = DateTime.Now - startTime;
            rotate2.Angle = (elapsedTime.TotalMinutes * 360) % 360;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.GoBack();
            StartTransition();
        }

        private void StartTransition()
        {
            //RollTransition rotatetransition = new RollTransition();
            RotateTransition rotatetransition = new RotateTransition();
            //rotatetransition.Mode = RotateTransitionMode.In90Clockwise;
            rotatetransition.Mode = RotateTransitionMode.In180Clockwise;

            PhoneApplicationPage phoneApplicationPage =
            (PhoneApplicationPage)(((PhoneApplicationFrame)Application.Current.RootVisual)).Content;

            ITransition transition = rotatetransition.GetTransition(phoneApplicationPage);

            transition.Completed += delegate
            {
                transition.Stop();
            };
            transition.Begin();
        }
 

        private Storyboard CreateStoryboard(double from, double to)
        {

            Storyboard result = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1.5));
            Storyboard.SetTarget(animation, this.TitlePanel);
            Storyboard.SetTargetProperty(animation, new PropertyPath(UIElement.OpacityProperty));
            result.Children.Add(animation);
            return result;
        }
            
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CreateStoryboard(1.0, 0.0).Begin();
            //NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            jiggleStoryboard.Begin();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            CreateStoryboard(0.0, 1.0).Begin();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(3000);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            RotateTransform rotateTransform = btn.RenderTransform as RotateTransform;

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

        private Ellipse GenerateEllipse()
        {
            Ellipse element = new Ellipse();
            element.Fill = new SolidColorBrush(Colors.White);
            element.Height = 8.0;
            element.Width = 8.0;
            this.ContentPanel.Children.Add(element);
            return element;
        }
        private Storyboard CreateStoryboard(UIElement element, double to, double toLeft)
        {
            Storyboard result = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = to;
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Top)"));
            Storyboard.SetTarget(animation, element);

            DoubleAnimation animationLeft = new DoubleAnimation();
            animationLeft.To = toLeft;
            Storyboard.SetTargetProperty(animationLeft, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTarget(animationLeft, element);

            result.Children.Add(animation);
            result.Children.Add(animationLeft);

            return result;
        }
        private void StartFallingSnowAnimation()
        {
            for (int i = 0; i < 20; i++)
            {
                Ellipse localCopy = this.GenerateEllipse();
                localCopy.SetValue(Canvas.LeftProperty, i * 30 + 1.0);

                double y = Canvas.GetTop(localCopy);
                double x = Canvas.GetLeft(localCopy);

                double speed = 5 * random.NextDouble();
                double index = 0;
                double radius = 30 * speed * random.NextDouble();

                localCopy.Opacity = .3 + random.NextDouble();

                CompositionTarget.Rendering += delegate(object o, EventArgs arg)
                {
                    index += Math.PI / (180 * speed);

                    if (y < this.ContentPanel.DesiredSize.Height)
                    {
                        y += .3 + speed;
                    }
                    else
                    {
                        y = -localCopy.Height;
                    }

                    Canvas.SetTop(localCopy, y);
                    Canvas.SetLeft(localCopy, x + radius * Math.Cos(index));
                    Storyboard animation = this.CreateStoryboard(localCopy, y, x + radius * Math.Cos(index));
                    Storyboard.SetTarget(animation, localCopy);
                    animation.Begin();

                };
            }
        }
    }
}
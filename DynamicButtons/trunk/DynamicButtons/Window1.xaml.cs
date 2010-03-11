using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TableTopCommunicator;

namespace DynamicButtons
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        Communicator comm = new Communicator();
        DispatcherTimer timer = new DispatcherTimer();
        int redScore = 0;
        int blueScore = 0;
        int yellowScore = 0;
        int greenScore = 0;
        int time = 60;

        public Window1()
        {
            InitializeComponent();

            lblTimer.Content = time;
            // Insert code required on object creation below this point.
            populateButtons();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            time = Int32.Parse(lblTimer.Content.ToString());
            time -= 1;
            lblTimer.Content = time;
            lblRedScore.Content = redScore;
            lblYellowScore.Content = yellowScore;
            lblBlueScore.Content = blueScore;
            lblGreenScore.Content = greenScore;
            if (time == 0)
            {
                timer.Stop();
            }
        }

        public void populateButtons()
        {
            int xPos;
            int yPos;

            Random ranNum = new Random();

            int topBuffer = 100;

            for (int i = 0; i < 100; i++)
            {

                Multitouch.Framework.WPF.Controls.Button foo = new Multitouch.Framework.WPF.Controls.Button();
                //Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(20, 100);

                foo.BorderThickness = new Thickness(0);
                foo.Width = sizeValue;
                foo.Height = sizeValue;

                xPos = ranNum.Next((int)SystemParameters.PrimaryScreenWidth);
                yPos = ranNum.Next(topBuffer, (int)SystemParameters.PrimaryScreenHeight);

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 20, 20);
                foo.Opacity = 0.5;

                //foo.Style = buttonStyle;
                foo.Name = "button" + i;

                foo.Click += new RoutedEventHandler(buttonClick);

                LayoutRoot.Children.Add(foo);
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                Button clicked = (Button)sender;
                Point relativePoint = clicked.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0));
                TouchInfo t = comm.EvalPoint((int)relativePoint.X, (int)relativePoint.Y);
                SolidColorBrush b;
                switch (t.Color)
                {
                    case "Red":
                        b = Brushes.Red;
                        break;
                    case "Yellow":
                        b = Brushes.Yellow;
                        break;
                    case "Blue":
                        b = Brushes.Blue;
                        break;
                    case "Green":
                        b = Brushes.Green;
                        break;
                    default:
                        b = Brushes.Olive;
                        break;
                }
                if (clicked.Background == Brushes.Red) redScore -= 1;
                if (clicked.Background == Brushes.Blue) blueScore -= 1;
                if (clicked.Background == Brushes.Yellow) yellowScore -= 1;
                if (clicked.Background == Brushes.Green) greenScore -= 1;
                clicked.Background = b;
                if (clicked.Background == Brushes.Red) redScore += 1;
                if (clicked.Background == Brushes.Blue) blueScore += 1;
                if (clicked.Background == Brushes.Yellow) yellowScore += 1;
                if (clicked.Background == Brushes.Green) greenScore += 1;
            }
        }
    }
}

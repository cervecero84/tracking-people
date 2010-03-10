using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using TableTopCommunicator;
using System.Windows.Threading;

namespace DynamicButtons
{
	public partial class Window1
	{
        Communicator comm = new Communicator();
        DispatcherTimer timer = new DispatcherTimer();
        int redScore = 0;
        int blueScore = 0;
        int time = 10;

		public Window1()
		{
			this.InitializeComponent();

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
            lblBlueScore.Content = blueScore;
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
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(20,80);

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
                    case "Yellow":
                        b = Brushes.Red;
                        break;
                    case "Blue":
                    case "Green":
                        b = Brushes.Blue;
                        break;
                    default:
                        b = Brushes.Olive;
                        break;
                }
                if (clicked.Background == Brushes.Red) redScore -= 1;
                if (clicked.Background == Brushes.Blue) blueScore -= 1;
                clicked.Background = b;
                if (clicked.Background == Brushes.Red) redScore += 1;
                if (clicked.Background == Brushes.Blue) blueScore += 1;
            }
        }
	}
}

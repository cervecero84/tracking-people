using System;
using System.Windows;
using System.Windows.Media;
using TableTopCommunicator;
using Multitouch.Framework.WPF.Input;
using Multitouch.Framework.WPF;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Fireflies
{

    public partial class GlowWindow
    {
        Communicator Comm = new Communicator();
        enum Colors { Blue, Green, Red, Yellow, White };
        string[] glowPaths = { "/Images/blueGlow.png", "/Images/greenGlow.png", "/Images/redGlow.png",
                               "/Images/yellowGlow.png", "/Images/whiteGlow.png" };
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer opacityTimer = new DispatcherTimer();

        public GlowWindow()
        {
            MultitouchScreen.AddContactEnterHandler(this, ElementEnterHandler);
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            opacityTimer.Interval = TimeSpan.FromMilliseconds(100);
            opacityTimer.Tick += new EventHandler(opacityTimer_Tick);
            timer.Tick += new EventHandler(timer_Tick);
            opacityTimer.Start();
            timer.Start();
        }

        void opacityTimer_Tick(object sender, EventArgs e)
        {
            UIElementCollection children = this.glowPanel.Children;
            Random r = new Random();
            for (int i = 0; i < children.Count; i++)
            {
                var glow = children[i] as Glow;
                glow.Opacity += ((r.NextDouble() - 0.8)/0.5) * 0.1;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            UIElementCollection children = this.glowPanel.Children;
            for (int i = 0; i < children.Count; i++)
            {
                var glow = children[0] as Glow;
                glow.Timer -= 1;
                if (glow.Timer == 0) children.Remove(glow);
            }
        }

        private static void ElementEnterHandler(object sender, ContactEventArgs e)
        {
            var element = sender as IInputElement;
            var winElement = sender as GlowWindow;

            if (element != null)
            {
                Glow newView;
                Point position = e.GetPosition(winElement);
                TouchInfo t = winElement.Comm.EvalPoint((int)position.X, (int)position.Y);

                Colors c;
                switch (t.Color)
                {
                    case TableTopCommunicator.Colors.Red:
                        c = Colors.Red;
                        break;
                    case TableTopCommunicator.Colors.Yellow:
                        c = Colors.Yellow;
                        break;
                    case TableTopCommunicator.Colors.Blue:
                        c = Colors.Blue;
                        break;
                    case TableTopCommunicator.Colors.Green:
                        c = Colors.Green;
                        break;
                    default:
                        c = Colors.White;
                        break;
                }
                
                newView = new Glow(winElement.glowPaths[(int)c]);
                newView.SetValue(Canvas.LeftProperty, position.X - 136 / 2);
                newView.SetValue(Canvas.TopProperty, position.Y - 138 / 2);
                MultitouchScreen.AddContactEnterHandler(newView, ElementEnterHandler2);
                winElement.glowPanel.Children.Add(newView);
            }
        }

        private static void ElementEnterHandler2(object sender, ContactEventArgs e)
        {
            var element = sender as IInputElement;
            if (element != null)
            {
                e.Contact.Capture(element);
            }
        }
    }
}

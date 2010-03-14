using System.Windows;
using System.Windows.Media;
using TableTopCommunicator;
using Multitouch.Framework.WPF.Input;
using Multitouch.Framework.WPF;
using System.Windows.Controls;


namespace Fireflies
{

    public partial class GlowWindow
    {
        Communicator Comm = new Communicator();
        enum Colors { Blue, Green, Red, Yellow, White };
        string[] glowPaths = { "/Images/blueGlow.png", "/Images/greenGlow.png", "/Images/redGlow.png",
                               "/Images/yellowGlow.png", "/Images/whiteGlow.png" };

        public GlowWindow()
        {
            MultitouchScreen.AddContactEnterHandler(this, ElementEnterHandler);
            MultitouchScreen.AddContactRemovedHandler(this, ElementRemoveHandler);

            InitializeComponent();
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
                    case "Red":
                        c = Colors.Red;
                        break;
                    case "Yellow":
                        c = Colors.Yellow;
                        break;
                    case "Blue":
                        c = Colors.Blue;
                        break;
                    case "Green":
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
                MultitouchScreen.AddContactRemovedHandler(newView, ElementRemoveHandler2);
                winElement.glowPanel.Children.Add(newView);
            }
        }

        private static void ElementRemoveHandler(object sender, ContactEventArgs e)
        {
            var element = sender as GlowWindow;
            element.glowPanel.Children.Remove(e.Contact.DirectlyOver as Glow);
        }

        private static void ElementRemoveHandler2(object sender, ContactEventArgs e)
        {
            var element = sender as Glow;
            GlowWindow glowWindow = Window.GetWindow(element) as GlowWindow;
            if (glowWindow != null)
            {
                glowWindow.glowPanel.Children.Remove(element);
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

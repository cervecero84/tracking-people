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

namespace Fireflies
{
    /// <summary>
    /// Interaction logic for Glow.xaml
    /// </summary>
    public partial class Glow : UserControl
    {
        public const int MAX_TIMER = 5;

        public Glow(string p)
        {
            Path = p;
            Timer = MAX_TIMER;
            InitializeComponent();
            
        }

        public string Path { 
            get; 
            set; 
        }

        public int Timer { get; set; }

    }
}

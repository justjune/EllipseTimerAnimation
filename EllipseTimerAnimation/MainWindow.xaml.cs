using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

namespace EllipseTimerAnimation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer t = new DispatcherTimer();
        private double time = 0;

        public MainWindow()
        {
            InitializeComponent();
            t.Tick += new EventHandler(OnTimer);
            t.Interval = new TimeSpan(0,0,0,0,50);
            t.Start();
        }
        void OnTimer(object sender, EventArgs e)
        {
            time = time + 0.1;
            double nu = 2 * Math.PI / 3;

            Polyline pl = (Polyline)this.FindName("pln");
            Ellipse el = (Ellipse)this.FindName("elps");
            Canvas cnv = (Canvas)FindName("cnv");

            double ch = cnv.ActualHeight;
            double cw = cnv.ActualWidth;

            pl.Points.Add(new Point(40 * time, ch / 2.0 + ch/4 * Math.Sin(nu * time)));
            //pl.Points.Add(new Point( (cw / 2.0 + 150.0 * Math.Cos(nu * time))*time/100, (ch / 2.0 + 150.0 * Math.Sin(nu * time))*time/100));
            
            Canvas.SetLeft(el, pl.Points.Last().X-el.Width/2.0);
            Canvas.SetTop(el, pl.Points.Last().Y-el.Height/2.0);
            
            if (time > 19) t.Stop();
        }
    }
}

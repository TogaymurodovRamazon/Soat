using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Timer = System.Timers.Timer;

namespace Soat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Timer timer = new Timer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Elapsed += vaqt_ketdi;
            timer.Interval = 600;
            timer.Enabled = true;
        }

        private void vaqt_ketdi(object sender, ElapsedEventArgs e)
        {
           // this.Dispatcher.Invoke(getDate);
           this.Dispatcher.Invoke(() =>
            {
                if (timeTxt.Opacity == 1)
                {
                    timeTxt.Opacity = 0.8;
                }
                else
                {
                    timeTxt.Opacity = 1;
                    getDate();
                }
            });
        }

        private void DrageBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)  
            this.DragMove();
            if (e.ClickCount == 2)
            {
                timer.Enabled= false;
                timer.Close();
            }
        }

        private void getDate()
        {
            timeTxt.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            DayTxt.Text = DateTime.Now.DayOfWeek.ToString();
            DateTxt.Text = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}

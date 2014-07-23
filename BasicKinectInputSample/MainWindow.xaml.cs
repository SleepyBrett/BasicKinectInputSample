using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System.Diagnostics;

using Microsoft.Kinect;
using Microsoft.Kinect.Input;

namespace BasicKinectInputSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        KinectSensor sensor = null;
        KinectCoreWindow kinectWindow = null;
        KinectGestureRecognizer kinectGestureRecognizer = null;

        public MainWindow()
        {
            this.sensor = KinectSensor.GetDefault();
            this.sensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;
            this.sensor.Open();
            KinectCoreWindow.SetKinectOnePersonSystemEngagement();
            this.kinectWindow = KinectCoreWindow.GetForCurrentThread();
            kinectGestureRecognizer = new KinectGestureRecognizer();
            this.kinectWindow.PointerEntered += this.Window_PointerEntered;
            this.kinectWindow.PointerExited += this.Window_PointerExited;
            this.kinectWindow.PointerMoved += this.Window_PointerMoved;


            Debug.WriteLine("IsAvail:" + this.sensor.IsAvailable);
            InitializeComponent();
        }




        private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            Debug.WriteLine("isAvailableChanged");
        }

        private void Window_PointerEntered( object sender, KinectPointerEventArgs e)
        {
            Debug.WriteLine("Pointer In!");

        }

        private void Window_PointerExited(object sender, KinectPointerEventArgs e)
        {
            Debug.WriteLine("Pointer Out!");

        }

        private void Window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            Debug.WriteLine(e.CurrentPoint.Position.X + " " + e.CurrentPoint.Position.Y);
        }

    }



}

using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using WebCamService;
using System.Drawing.Imaging;
using System.Windows.Media;

namespace HPClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            const int VIDEODEVICE = 0; // zero based index of video capture device to use
            const int FRAMERATE = 15;  // Depends on video device caps.  Generally 4-30.
            const int VIDEOWIDTH = 640; // Depends on video device caps
            const int VIDEOHEIGHT = 480; // Depends on video device caps
            const long JPEGQUALITY = 30; // 1-100 or 0 for default
             

            Capture cam = null;

            cam = new Capture(VIDEODEVICE, FRAMERATE, VIDEOWIDTH, VIDEOHEIGHT);

            cam.Start();

            IntPtr ip = cam.GetBitMap();

            Bitmap image = new Bitmap(cam.Width, cam.Height, cam.Stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, ip);

            //TODO display image in a normal way
            Form1 Form = new Form1();
            Form.pictureBox1.Image = image;
            Form.Show();          

        }
    }
}

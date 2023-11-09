using Microsoft.Win32;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System.Windows;

namespace FaceDetectionWithOpenCvSharp
{
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CascadeClassifier faceCascade = new CascadeClassifier("haarcascade_frontalface_alt2.xml");

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files | *.jpg;*jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                using Mat image = new Mat(openFileDialog.FileName, ImreadModes.Color);
                OpenCvSharp.Rect[] faces = faceCascade.DetectMultiScale(image);

                foreach (OpenCvSharp.Rect face in faces)
                {
                    image.Rectangle(face, new Scalar(0, 255, 0), 3);
                }

                imgMain.Source = image.ToBitmapSource();
            }

        }
    }
}

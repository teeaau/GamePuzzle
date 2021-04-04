using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace GamePuzzle.view_models
{
    public class SelectImage
    {
        public BitmapImage image { get; set; }
        public SelectImage()
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Title = "Select a image for game";
            open_file.Filter = "Image File (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF, *.SGV)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.SGV|All files (*.*)|*.*";
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                string uri = open_file.FileName;
                image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(uri, UriKind.Relative);
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
            }
        }
    }
}

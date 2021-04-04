using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GamePuzzle.models
{
    public class MatrixImage
    {
        private Image[,] matrix;
        private BitmapImage image;
        private int rows;
        private int cols;
        public MatrixImage(BitmapImage image, int rows, int cols)
        {
            this.image = image;
            this.rows = rows;
            this.cols = cols;
        }
        public Image[,] Matrix
        {
            get { return matrix; }
        }
        public void Split()
        {
            matrix = new Image[rows, cols];
            int wid = image.PixelWidth / cols;
            int hei = image.PixelHeight / rows;
            
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    matrix[i, j] = new Image();
                    CroppedBitmap img = new CroppedBitmap(image, new Int32Rect(j * wid, i * hei, wid, hei));
                    matrix[i, j].Source = img;
                    matrix[i, j].Stretch = Stretch.Fill;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GamePuzzle.functions;
using GamePuzzle.models;
using GamePuzzle.views;
namespace GamePuzzle.view_models
{
    public class MainViewModel
    {
        public BitmapImage image { get; set; }
        private MatrixBox matrix_box;
        private MatrixImage matrix_image;
        private int rows;
        private int cols;
        private Grid gridPlay;
        private Grid gridPicture;
        private AutoPlay auto;
        public MainViewModel(Grid gridPlay, Grid gridPicture)
        {
            this.rows = 3;
            this.cols = 3;
            this.image = new BitmapImage(new Uri("C:\\Users\\chang\\Desktop\\TeeAau\\Lap trinh Windows\\GameXepHinh\\images\\1.jpg", UriKind.Relative));
            this.gridPlay = gridPlay;
            this.gridPicture = gridPicture;
        }
        public void Select()
        {
            SelectImage select = new SelectImage();
            if (select.image == null) { return; }
            image = select.image;
            matrix_box.image = image;
            if (matrix_box == null || Checker.IsTrue(matrix_box, rows, cols))
            {
                Level(rows, cols);
            }
            else
            {
                matrix_image = new MatrixImage(image, rows, cols);
                matrix_image.Split();
                matrix_box.matrix_image = matrix_image;
                matrix_box.Keep();
            }
            SetGrid.SetImage(gridPicture, image);
        }
        public void Level(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix_box = new MatrixBox(image, rows, cols);
            matrix_box.Shuffle();
            matrix_box.Fill(gridPlay);
        }
        public void New()
        {
            Level(rows, cols);
        }        
        public void ConfigAuto()
        {
            auto = new AutoPlay();
        }
        public void AutoPlay()
        {
            if(rows != 3 && cols != 3)
            {
                MessageBox.Show("Just for easy game");
                return;
            }
            auto.Play(matrix_box, gridPlay);
        }
        public void KeyDown(KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Up:
                    MoveEvent.Up(matrix_box);
                    break;
                case Key.Down:
                    MoveEvent.Down(matrix_box);
                    break;
                case Key.Left:
                    MoveEvent.Left(matrix_box);
                    break;
                case Key.Right:
                    MoveEvent.Right(matrix_box);
                    break;
                default:
                    break;
            }
            if(Checker.IsTrue(matrix_box, rows, cols))
            {
                SetGrid.SetDefault(gridPlay);
                SetGrid.SetImage(gridPlay, image);
            }
        }
    }
}

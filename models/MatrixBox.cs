using GamePuzzle.functions;
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
    public class MatrixBox
    {
        public Box[,] matrix { get; set; }
        public MatrixImage matrix_image { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        private int[] shuffle_array;
        public BitmapImage image { get; set; }
        public MatrixBox(BitmapImage image, int rows, int cols)
        {
            this.image = image;
            this.rows = rows;
            this.cols = cols;
            matrix_image = new MatrixImage(image, rows, cols);
            matrix_image.Split();
            matrix = new Box[rows, cols];
        }
        public MatrixBox(BitmapImage image, MatrixImage matrix_image, int rows, int cols)
        {
            this.image = image;
            this.rows = rows;
            this.cols = cols;
            this.matrix_image = matrix_image;
            matrix = new Box[rows, cols];
        }
        private int[] ShuffleArray()
        {
            int u = rows - 1;
            int v = cols - 1;
            int[] X = { 0, 0, 1, -1 };
            int[] Y = { 1, -1, 0, 0 };
            int[] shuffle_arr = Enumerable.Range(0, rows * cols).ToArray();
            Random random = new Random();
            for (int i = 0; i < 1000000; ++i)
            {
                int j = random.Next(0, 4);
                int x = X[j] + u;
                int y = Y[j] + v;
                if (x < 0 || x >= rows)
                    continue;
                if (y < 0 || y >= cols)
                    continue;
                int temp = shuffle_arr[u * cols + v];
                shuffle_arr[u * cols + v] = shuffle_arr[x * cols + y];
                shuffle_arr[x * cols + y] = temp;
                u = x;
                v = y;
            }
            for (int i = u + 1; i < rows; ++i)
            {
                int temp = shuffle_arr[u * cols + v];
                shuffle_arr[u * cols + v] = shuffle_arr[i * cols + v];
                shuffle_arr[i * cols + v] = temp;
                u = i;
            }
            for (int i = v + 1; i < cols; ++i)
            {
                int temp = shuffle_arr[u * cols + v];
                shuffle_arr[u * cols + v] = shuffle_arr[u * cols + i];
                shuffle_arr[u * cols + i] = temp;
                v = i;
            }
            return shuffle_arr;
        }
        public void Shuffle()
        {
            shuffle_array = ShuffleArray();
            Empty.X = rows - 1;
            Empty.Y = cols - 1;
        }
        public void Fill(Grid gridPlay)
        {
            SetGrid.SetDefault(gridPlay);
            SetGrid.SetRowDef(gridPlay, rows);
            SetGrid.SetColumnDef(gridPlay, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    int u = i, v = j;
                    if (i == rows - 1 && j == cols - 1) { break; }
                    int r = shuffle_array[i * cols + j] / cols;
                    int c = shuffle_array[i * cols + j] % cols;
                    matrix[i, j] = new Box(matrix_image.Matrix[i, j], r, c, i, j);
                    Grid.SetRow(matrix[i, j].box, r);
                    Grid.SetColumn(matrix[i, j].box, c);
                    matrix[i, j].box.Click += new RoutedEventHandler((sender, e) => Box_Click(sender, e, matrix[u, v], gridPlay)); 
                    gridPlay.Children.Add(matrix[i, j].box);
                }
            }
        }
        public void Keep()
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i == rows - 1 && j == cols - 1) { break; }
                    int r_corr = matrix[i, j].corr_row;
                    int c_corr = matrix[i, j].corr_col;
                    int r_curr = matrix[i, j].curr_row;
                    int c_curr = matrix[i, j].curr_col;
                    matrix[r_corr, c_corr].box.Content = matrix_image.Matrix[r_corr, c_corr];
                }
            }
        }
        private void Box_Click(object sender, RoutedEventArgs e, Box box, Grid gridPlay)
        {
            MoveEvent.Click(box);
            if(Checker.IsTrue(this, rows, cols))
            {
                SetGrid.SetDefault(gridPlay);
                SetGrid.SetImage(gridPlay, image);
            }
        }
    }
}

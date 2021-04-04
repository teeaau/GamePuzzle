using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GamePuzzle.functions
{
    public static class SetGrid
    {
        public static void SetImage(Grid grid, BitmapImage image)
        {
            ImageBrush img = new ImageBrush(image);
            img.Stretch = Stretch.Fill;
            grid.Background = img;
        }
        public static void SetDefault(Grid grid)
        {
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            grid.Background = null;
        }
        public static void SetColumnDef(Grid grid, int cols)
        {
            for(int i = 0; i < cols; ++i)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = new GridLength(1.0, GridUnitType.Star);
                grid.ColumnDefinitions.Add(col);
            }
        }
        public static void SetRowDef(Grid grid, int rows)
        {
            for (int i = 0; i < rows; ++i)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1.0, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }
        }
    }
}

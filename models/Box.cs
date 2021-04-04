using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GamePuzzle.models
{
    public class Box
    {
        public Button box { get; set; }
        public int curr_row { get; set; }
        public int curr_col { get; set; }
        public int corr_row { get; set; }
        public int corr_col { get; set; }
        public Box(Image image, int curr_row, int curr_col, int corr_row, int corr_col)
        {
            this.curr_row = curr_row;
            this.curr_col = curr_col;
            this.corr_row = corr_row;
            this.corr_col = corr_col;
            box = new Button();
            box.Content = image;
        }
    }
}

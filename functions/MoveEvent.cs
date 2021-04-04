using GamePuzzle.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GamePuzzle.functions
{
    public static class MoveEvent
    {
        public static void Click(Box box)
        {
            int check = Math.Abs(box.curr_row - Empty.X) + Math.Abs(box.curr_col - Empty.Y);
            if (check != 1)
                return;
            Grid.SetRow(box.box, Empty.X);
            Grid.SetColumn(box.box, Empty.Y);
            int temp = box.curr_row;
            box.curr_row = Empty.X;
            Empty.X = temp;
            temp = box.curr_col;
            box.curr_col = Empty.Y;
            Empty.Y = temp;
        }
        public static void Up(MatrixBox matrix_box)
        {
            Move(matrix_box, 1, 0);
        }
        public static void Down(MatrixBox matrix_box)
        {
            Move(matrix_box, -1, 0);
        }
        public static void Left(MatrixBox matrix_box)
        {
            Move(matrix_box, 0, 1);
        }
        public static void Right(MatrixBox matrix_box)
        {
            Move(matrix_box, 0, -1);
        }
        public static void Move(MatrixBox matrix_box, int _x, int _y)
        {
            int rows = matrix_box.rows;
            int cols = matrix_box.cols;
            int r = rows - 1, c = cols - 1;
            for(int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < cols; ++j)
                {
                    if(i == rows - 1 && j == cols - 1) { break; }
                    if((matrix_box.matrix[i, j].curr_row == Empty.X + _x) && (matrix_box.matrix[i, j].curr_col == Empty.Y + _y))
                    {
                        r = i; c = j;
                    }
                }
            }
            if (r == rows - 1 && c == cols - 1) { return; }
            Grid.SetRow(matrix_box.matrix[r, c].box, Empty.X);
            Grid.SetColumn(matrix_box.matrix[r, c].box, Empty.Y);
            int temp = matrix_box.matrix[r, c].curr_row;
            matrix_box.matrix[r, c].curr_row = Empty.X;
            Empty.X = temp;
            temp = matrix_box.matrix[r, c].curr_col;
            matrix_box.matrix[r, c].curr_col = Empty.Y;
            Empty.Y = temp;
        }
    }
}

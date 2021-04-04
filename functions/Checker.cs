using GamePuzzle.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePuzzle.functions
{
    public static class Checker
    {
        public static bool IsTrue(MatrixBox matrix_box, int rows, int cols)
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i == rows - 1 && j == cols - 1) { break; }
                    //if (matrix_box.matrix[i, j].curr_row != matrix_box.matrix[i, j].corr_row)
                    //    return false;
                    //if (matrix_box.matrix[i, j].curr_col != matrix_box.matrix[i, j].corr_col)
                    //    return false;
                    if (matrix_box.matrix[i, j].curr_row != i)
                        return false;
                    if (matrix_box.matrix[i, j].curr_col != j)
                        return false;
                }
            }
            return true;
        }
    }
}

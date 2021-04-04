using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using GamePuzzle.functions;
using GamePuzzle.models;

namespace GamePuzzle.view_models
{
    public class AutoPlay
    {
        private Dictionary<long, long> tree = new Dictionary<long, long>();
        private Dictionary<long, long> trace = new Dictionary<long, long>();
        private int[] X = { 1, -1, 0, 0 };
        private int[] Y = { 0, 0, -1, 1 };
        public AutoPlay()
        {
            BuildTree();
        }
        private void BuildTree()
        {
            long _case = 12345678;
            tree[_case] = 0;
            trace[0] = _case;
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(_case);
            while(queue.Count != 0)
            {                
                _case = queue.Dequeue();
                var matrix = ToMatrix(_case);
                for(long i = 0; i < 3; ++i)
                {
                    for(long j = 0; j < 3; ++j)
                    {
                        if(matrix[i, j] != 8) { continue; }
                        for(long k = 0; k < 4; ++k)
                        {
                            long u = i + X[k];
                            long v = j + Y[k];
                            if (u > 2 || u < 0 || v > 2 || v < 0) { continue; }
                            Swap(ref matrix[i, j], ref matrix[u, v]);
                            long _next = ToInt(matrix);
                            if(!tree.ContainsKey(_next))
                            {
                                tree[_next] = tree[_case] * 4 + k + 1;
                                trace[tree[_case] * 4 + k + 1] = _next;
                                queue.Enqueue(_next);
                            }
                            Swap(ref matrix[i, j], ref matrix[u, v]);
                        }
                    }
                }
            }
        }
        public async void Play(MatrixBox matrix_box, Grid gridPlay)
        {
            long[,] matrix = new long[3, 3];
            for (long i = 0; i < 3; ++i)
                for (long j = 0; j < 3; ++j)
                    matrix[i, j] = -1;
            for (long i = 0; i < 3; ++i)
            {
                for (long j = 0; j < 3; ++j)
                {
                    if (i == 2 && j == 2) { break; }
                    matrix[matrix_box.matrix[i, j].curr_row, matrix_box.matrix[i, j].curr_col] = i * 3 + j;
                }
            }
            for (long i = 0; i < 3; ++i)
                for (long j = 0; j < 3; ++j)
                    if (matrix[i, j] == -1) { matrix[i, j] = 8; }

            long _curr = tree[ToInt(matrix)];
            while (_curr != 0)
            {
                long _x = (_curr - 1) % 4;
                MoveEvent.Move(matrix_box, (-1) * X[_x], (-1) * Y[_x]);
                await Task.Delay(500);
                _curr = (_curr - 1) / 4;              
            }
            SetGrid.SetDefault(gridPlay);
            SetGrid.SetImage(gridPlay, matrix_box.image);
        }
        private long ToInt(long[,] matrix)
        {
            long _case = 0;
            for(long i = 0; i < 3; ++i)
            {
                for(long j = 0; j < 3; ++j)
                {
                    _case = _case * 10 + matrix[i, j];
                }
            }
            return _case;
        }
        private long[,] ToMatrix(long _case)
        {
            long[,] matrix = new long[3, 3];
            for(long i = 2; i >= 0; --i)
            {
                for(long j = 2; j >= 0; --j)
                {
                    matrix[i, j] = _case % 10;
                    _case /= 10;
                }
            }
            return matrix;
        }
        private void Swap(ref long _x, ref long _y)
        {
            long temp = _x;
            _x = _y;
            _y = temp;
        }
    }
}

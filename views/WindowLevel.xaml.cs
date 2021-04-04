using GamePuzzle.view_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GamePuzzle.views
{
    /// <summary>
    /// Interaction logic for WindowLevel.xaml
    /// </summary>
    public partial class WindowLevel : Window
    {
        public int rows { get; set; }
        public int cols { get; set; }
        public MainViewModel controller;
        public WindowLevel(MainViewModel controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void chbCustom_Checked(object sender, RoutedEventArgs e)
        {
            btnEasy.IsEnabled = false;
            btnNormal.IsEnabled = false;
            btnHard.IsEnabled = false;
        }

        private void chbCustom_Unchecked(object sender, RoutedEventArgs e)
        {
            btnEasy.IsEnabled = true;
            btnNormal.IsEnabled = true;
            btnHard.IsEnabled = true;
        }

        private void btnEasy_Click(object sender, RoutedEventArgs e)
        {
            this.rows = 3;
            this.cols = 3;
            this.Close();
        }

        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            this.rows = 5;
            this.cols = 5;
            this.Close();
        }

        private void btnHard_Click(object sender, RoutedEventArgs e)
        {
            this.rows = 8;
            this.cols = 8;
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.rows = (int)sldRows.Value;
            this.cols = (int)sldCols.Value;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            controller.Level(rows, cols);
        }
    }
}

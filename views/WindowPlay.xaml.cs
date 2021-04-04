using GamePuzzle.functions;
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
    public partial class WindowPlay : Window
    {
        private MainViewModel controller;
        public WindowPlay()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            controller.New();
        }

        private void btnLevel_Click(object sender, RoutedEventArgs e)
        {
            WindowLevel windowLevel = new WindowLevel(controller);
            windowLevel.Show();
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            controller.Select();
        }

        private void btnAutoPlay_Click(object sender, RoutedEventArgs e)
        {
            if (controller == null) return;            
            controller.AutoPlay();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controller = new MainViewModel(gridPlay, gridPicture);
            controller.ConfigAuto();
            SetGrid.SetImage(gridPicture, controller.image);
            SetGrid.SetImage(gridPlay, controller.image);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            controller.KeyDown(e);
        }
    }
}

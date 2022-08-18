using CommunityToolkit.Mvvm.DependencyInjection;
using LevelEditor.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LevelEditor.Controls
{
    /// <summary>
    /// Interaction logic for TileControl.xaml
    /// </summary>
    public partial class TileControl : UserControl
    {
        private MainWindow mainWindow;

        public TileViewModel ViewModel => (TileViewModel)DataContext;

        public TileControl(MainWindow window)
        {
            InitializeComponent();
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance<TileViewModel>(Ioc.Default);
            mainWindow = window;

        }

        private void Tile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.TileImage.Source = mainWindow.TileImages[mainWindow.SelectedImage];
        }


    }
}

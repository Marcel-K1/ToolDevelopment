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

        private Tile tile;

        public TileViewModel ViewModel => (TileViewModel)DataContext;

        public TileControl(MainWindow window, Tile tile)
        {

            InitializeComponent();
            DataContext = ActivatorUtilities.GetServiceOrCreateInstance<TileViewModel>(Ioc.Default);

            mainWindow = window;
            this.tile = tile;

        }

        private void Tile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.TileImage.Source = mainWindow.TileImages[mainWindow.SelectedImage];
            tile.TileType = mainWindow.SelectedImage;
        }

        private void Cut_CommandBindingExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.TileImage.Source = mainWindow.TileImages[mainWindow.DefaultImage];
            tile.TileType = mainWindow.DefaultImage;
        }

        private void CanAlwaysExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

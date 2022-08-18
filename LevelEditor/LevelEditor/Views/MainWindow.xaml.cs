using CommunityToolkit.Mvvm.DependencyInjection;
using LevelEditor.ViewModels;
using LevelEditor.Views;
using LevelEditor.Models;
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
using LevelEditor.Properties;
using System.ComponentModel;
using Microsoft.Win32;
using LevelEditor.Controls;

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DIALOG_FILTERS = "Data Files|*.dat;*.bin|Alle Dateien (*.*)|*.*";

        public enum Tiles
        {
            Water,
            Grass,
            Ground
        }

        public static RoutedUICommand CustomOpenCommand = new RoutedUICommand("_Open", "CustomOpen", typeof(MainWindow), new InputGestureCollection
        {
            new KeyGesture(Key.A, ModifierKeys.Alt)
        });


        public Dictionary<Tiles, ImageSource> tileImages = new Dictionary<Tiles, ImageSource>();
        public Dictionary<Tiles, ImageSource> TileImages { get => tileImages; set => tileImages = value; }

        private Tiles selectedImage = Tiles.Grass;
        public Tiles SelectedImage { get => selectedImage; set => selectedImage = value; }

        private List<Tile> tilesList;
        public List<Tile> TilesList { get => tilesList; set => tilesList = value; }

        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(DataContextProperty);
            set => SetValue(DataContextProperty, value);
        }

        public MainWindow()
        {
            InitializeComponent();

            InitializeMainWindow();

            ViewModel = Ioc.Default.GetRequiredService<MainViewModel>();

            TileImages[Tiles.Water] = new ImageSourceConverter().ConvertFrom(new Uri("Icons/water.png", UriKind.Relative)) as ImageSource; 
            TileImages[Tiles.Grass] = new ImageSourceConverter().ConvertFrom(new Uri("Icons/grass.png", UriKind.Relative)) as ImageSource; 
            TileImages[Tiles.Ground] = new ImageSourceConverter().ConvertFrom(new Uri("Icons/ground.png", UriKind.Relative)) as ImageSource;

            DrawGrid();
            SetGrid();

        }


        private void DrawGrid()
        {
            for (int x = 0; x < 3; x++)
            {
                var rd = new RowDefinition();
                rd.Height = new GridLength(200);
                EditorGrid.RowDefinitions.Add(rd);

            }

            for (int y = 0; y < 3; y++)
            {
                var cd = new ColumnDefinition();
                cd.Width = new GridLength(200);
                EditorGrid.ColumnDefinitions.Add(cd);
            }

        }
        private void SetGrid()
        {

            tilesList = new List<Tile>();

            for (int x = 0; x < 3; x++)
            {

                for (int y = 0; y < 3; y++)
                {
                    Tile tile = new Tile(this);
                    tile.TileControl.TileImage.Source = tileImages[selectedImage];

                    EditorGrid.Children.Add(tile.TileControl);

                    //Wichtig fürs Speichern:
                    tile.X = x;
                    tile.Y = y;
                    tilesList.Add(tile);

                    Grid.SetRow(tile.TileControl, x);
                    Grid.SetColumn(tile.TileControl, y);
                }
            }

        }



        private void InitializeMainWindow()
        {
            Height = Settings.Default.MainWindowHeight;
            Width = Settings.Default.MainWindowWidth;
            Top = Settings.Default.MainWindowTop;
            Left = Settings.Default.MainWindowLeft;

            if (Settings.Default.Maximized)
            {
                WindowState = WindowState.Maximized;
            }

            this.Closing += Window_Closing;

        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {

            if (WindowState == WindowState.Maximized)
            {
                Settings.Default.MainWindowTop = RestoreBounds.Top;
                Settings.Default.MainWindowLeft = RestoreBounds.Left;
                Settings.Default.MainWindowHeight = RestoreBounds.Height;
                Settings.Default.MainWindowWidth = RestoreBounds.Width;
                Settings.Default.Maximized = true;
            }
            else
            {
                Settings.Default.MainWindowTop = this.Top;
                Settings.Default.MainWindowLeft = this.Left;
                Settings.Default.MainWindowHeight = this.Height;
                Settings.Default.MainWindowWidth = this.Width;
                Settings.Default.Maximized = false;
            }

            Settings.Default.Save();

        }



        private void OnPreferencesClick(object sender, RoutedEventArgs e)
        {
            var window = new PreferencesWindow();
            window.ShowDialog();
        }
        private void OnProjectSettingsClick(object sender, RoutedEventArgs e)
        {
            var window = new ProjectSettingsWindow();
            window.ShowDialog();
        }
        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void WaterButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage = Tiles.Water;
        }
        private void GrassButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage = Tiles.Grass;
        }
        private void GroundButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedImage = Tiles.Ground;
        }



        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = DIALOG_FILTERS;
            if (ofd.ShowDialog() ?? false)
            {
                string filename = ofd.FileName;

                try
                {
                    List<Tile> tileList = LevelSerializer.Load(filename);

                    if (tileList != null)
                    {
                        EditorGrid.Children.Clear();
                        foreach (var tile in tileList)
                        {
                            EditorGrid.Children.Add(tile.TileControl);
                            Grid.SetRow(tile.TileControl, tile.X);
                            Grid.SetColumn(tile.TileControl, tile.Y);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = DIALOG_FILTERS;
            if (sfd.ShowDialog() ?? false)
            {
                string filename = sfd.FileName;

                try
                {
                    LevelSerializer.Save(filename, tilesList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void HelpCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/view/leveleditor-hilfe/startseite");
        }
        private void CanAlwaysExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = true;

        }

    }
}

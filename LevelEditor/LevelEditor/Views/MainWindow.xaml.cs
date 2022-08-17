using CommunityToolkit.Mvvm.DependencyInjection;
using LevelEditor.ViewModels;
using LevelEditor.Views;
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

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Tiles
        {
            Water,
            Grass,
            Ground
        }

        Dictionary<Tiles, Image> tileImages = new Dictionary<Tiles, Image>();

        Tiles selectedImage = Tiles.Grass;

        //Tiles[,] tilemap = new Tiles[10, 10];

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = Ioc.Default.GetRequiredService<MainViewModel>();

            Image waterImage = new Image();
            BitmapImage myBitmapImage1 = new BitmapImage();
            myBitmapImage1.BeginInit();
            myBitmapImage1.UriSource = new Uri(@"C:\Users\Klein\Documents\GitHub\Eigenprojekte\ToolDevelopment_Abgabe\LevelEditor\LevelEditor\Icons\water.png");
            myBitmapImage1.EndInit();
            waterImage.Source = myBitmapImage1;

            Image grassImage = new Image();
            BitmapImage myBitmapImage2 = new BitmapImage();
            myBitmapImage2.BeginInit();
            myBitmapImage2.UriSource = new Uri(@"C:\Users\Klein\Documents\GitHub\Eigenprojekte\ToolDevelopment_Abgabe\LevelEditor\LevelEditor\Icons\grass.png");
            myBitmapImage2.EndInit();
            grassImage.Source = myBitmapImage2;

            Image groundImage = new Image();
            BitmapImage myBitmapImage3 = new BitmapImage();
            myBitmapImage3.BeginInit();
            myBitmapImage3.UriSource = new Uri(@"C:\Users\Klein\Documents\GitHub\Eigenprojekte\ToolDevelopment_Abgabe\LevelEditor\LevelEditor\Icons\ground.png");
            myBitmapImage3.EndInit();
            groundImage.Source = myBitmapImage3;

            //Wir weisen jedem Key des Dictionaries einen Value zu:
            tileImages[Tiles.Water] = waterImage;
            tileImages[Tiles.Grass] = grassImage;
            tileImages[Tiles.Ground] = groundImage;
        }

        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(DataContextProperty);
            set => SetValue(DataContextProperty, value);
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


        //private void buttonClick(object sender, RoutedEventArgs e)
        //{

        //    for (int x = 0; x < 10; x++)
        //    {
        //        for (int y = 0; y < 10; y++)
        //        {
        //            Image image = new Image();
        //            //image.Name = x.ToString() + "," + y.ToString();
        //            image.DragOver += OnDragOver;

        //        }

        //    }
        //}

        //void OnDragOver(object sender, RoutedEventArgs e)
        //{
        //    var image = sender as Image;

        //    // name="x15_33"
        //    string name = image.Name.Substring(1);
        //    string[] coords = name.Split('_');
        //    int xCoord = int.Parse(coords[0]);
        //    int yCoord = int.Parse(coords[1]);
        //    image.Source = tileImages[selectedImage];
        //    tilemap[xCoord, yCoord] = selectedImage;
        //}

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    Stream stream = new FileStream("level.dat", FileMode.OpenOrCreate);
        //    bf.Serialize(stream, tilemap);
        //}

        //private void x0_0_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    //OnDragOver(sender, e);
        //}



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            selectedImage = Tiles.Water;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Image.Source = tileImages[selectedImage].Source;
        }



        private void WaterButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedImage = Tiles.Water;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image.Source = tileImages[selectedImage].Source;
        }




        private void GrassButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedImage = Tiles.Grass;
        }

        private void GroundButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedImage = Tiles.Ground;
        }





        //private void AddOrRemoveImage(object sender, MouseButtonEventArgs e)
        //{
        //    Brush customColor;
        //    Random r = new Random();

        //    if (e.OriginalSource is Rectangle)
        //    {
        //        Rectangle activeRectangle = (Rectangle)e.OriginalSource;

        //        CustomCanvas.Children.Remove(activeRectangle);
        //    }
        //    else
        //    {
        //        customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));

        //        Rectangle newRectangle = new Rectangle
        //        {

        //            Width = 50,
        //            Height = 50,

        //            Fill = customColor,
        //            StrokeThickness = 3,
        //            Stroke = Brushes.Black

        //        };

        //        Canvas.SetLeft(newRectangle, Mouse.GetPosition(CustomCanvas).X);
        //        Canvas.SetTop(newRectangle, Mouse.GetPosition(CustomCanvas).Y);

        //        CustomCanvas.Children.Add(newRectangle);
        //    }
        //}

        private void DrawGrid()
        {
            #region Drawing on Canvas

            //double HCanvas = CustomCanvas.ActualHeight;
            //double WCanvas = CustomCanvas.ActualWidth;

            //Border border = new Border()
            //{
            //    Width = WCanvas,
            //    Height = HCanvas,
            //    Background = Brushes.LightYellow,
            //    BorderBrush = Brushes.Red,
            //    BorderThickness = new Thickness(3)
            //};

            //CustomCanvas.Children.Add(border);

            //for (int i = 0; i < HCanvas / 20; i++)
            //{
            //    double space = i * 20;
            //    Line line = new Line()
            //    {
            //        X1 = 0,
            //        X2 = WCanvas,
            //        Y1 = space,
            //        Y2 = space,
            //        StrokeThickness = 1,
            //        Stroke = Brushes.Black

            //    };

            //    CustomCanvas.Children.Add(line);
            //}

            //for (int i = 0; i < WCanvas / 20; i++)
            //{
            //    double space = i * 20;
            //    Line line = new Line()
            //    {
            //        Y1 = 0,
            //        Y2 = HCanvas,
            //        X1 = space,
            //        X2 = space,
            //        StrokeThickness = 1,
            //        Stroke = Brushes.Black

            //    };

            //    CustomCanvas.Children.Add(line);
            //}

            //for (int y = 0; y < WCanvas / 20; y++)
            //{

            //    for (int x = 0; x < HCanvas / 20; x++)
            //    {
            //        Image image = new Image()
            //        {
            //            Height = HCanvas / 20,
            //            Width = WCanvas / 20
            //        };

            //        Canvas.SetLeft(image, y);
            //        Canvas.SetTop(image, x);
            //        CustomCanvas.Children.Add(image);
            //    }
            //}

            #endregion

            #region Building Grid inside Canvas

            Grid DynamicGrid = new Grid()
            {
                Width = 400,

                Height = 400,

                HorizontalAlignment = HorizontalAlignment.Center,

                VerticalAlignment = VerticalAlignment.Center,

                ShowGridLines = true,

                Background = new SolidColorBrush(Colors.LightSteelBlue),

            };
            CustomCanvas.Children.Add(DynamicGrid);

            for (int i = 0; i < 10; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();


                DynamicGrid.ColumnDefinitions.Add(gridCol);
            }

            for (int i = 0; i < 10; i++)
            {
                RowDefinition gridRow = new RowDefinition();

                DynamicGrid.RowDefinitions.Add(gridRow);
            }

            #endregion

        }


        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    DrawGrid();
        //}

    }
}

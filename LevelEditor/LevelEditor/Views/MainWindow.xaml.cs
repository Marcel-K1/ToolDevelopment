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

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = Ioc.Default.GetRequiredService<MainViewModel>();
            //DrawGrid();
        }

        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(DataContextProperty);
            set => SetValue(DataContextProperty, value);
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            var window = new PreferencesWindow();
            window.ShowDialog();
        }

        private void ProjectSettings_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProjectSettingsWindow();
            window.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOrRemoveImage(object sender, MouseButtonEventArgs e)
        {
            Brush customColor;
            Random r = new Random();

            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;

                CustomCanvas.Children.Remove(activeRectangle);
            }
            else
            {
                customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));

                Rectangle newRectangle = new Rectangle
                {

                    Width = 50,
                    Height = 50,
                    Fill = customColor,
                    StrokeThickness = 3,
                    Stroke = Brushes.Black

                };

                Canvas.SetLeft(newRectangle, Mouse.GetPosition(CustomCanvas).X);
                Canvas.SetTop(newRectangle, Mouse.GetPosition(CustomCanvas).Y);

                CustomCanvas.Children.Add(newRectangle);
            }
        }

        private void DrawGrid()
        {
            double HCanvas = CustomCanvas.ActualHeight;
            double WCanvas = CustomCanvas.ActualWidth;

            double[] vertices = new double[(int)((HCanvas +1f) * (WCanvas+1f))];

            Border border = new Border()
            {
                Width = WCanvas,
                Height = HCanvas,
                Background = Brushes.LightYellow,
                BorderBrush = Brushes.Red,
                BorderThickness = new Thickness(3)
            };

            CustomCanvas.Children.Add(border);

            for (int i = 0; i < HCanvas/ 20; i++)
            {
                double space = i * 20;
                Line line = new Line()
                {
                    X1 = 0,
                    X2 = WCanvas,
                    Y1 = space,
                    Y2 = space,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black

                };

                CustomCanvas.Children.Add(line);
            }

            for (int i = 0; i < WCanvas / 20; i++)
            {
                double space = i * 20;
                Line line = new Line()
                {
                    Y1 = 0,
                    Y2 = HCanvas,
                    X1 = space,
                    X2 = space,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black

                };

                CustomCanvas.Children.Add(line);
            }

            for (int y = 0; y < WCanvas / 20; y++)
            {

                for (int x = 0; x < HCanvas / 20; x++)
                {
                    Image image = new Image()
                    {
                        Height = HCanvas / 20,
                        Width = WCanvas / 20
                    };

                    CustomCanvas.Children.Add(image);
                    Canvas.SetLeft(image, y);
                    Canvas.SetTop(image, x);
                }
            }

            //for (int i = 0; i < vertices; i++)
            //{

            //}

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGrid();
        }
    }
}

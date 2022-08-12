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
    }
}

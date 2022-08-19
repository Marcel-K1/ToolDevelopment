﻿using CommunityToolkit.Mvvm.DependencyInjection;
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
using System.Windows.Shapes;

namespace LevelEditor.Views
{
    /// <summary>
    /// Interaction logic for ProjectSettingsWindow.xaml
    /// </summary>
    public partial class ProjectSettingsWindow : Window
    {

        public ProjectSettingsViewModel ViewModel
        {
            get => (ProjectSettingsViewModel)GetValue(DataContextProperty);
            set => SetValue(DataContextProperty, value);
        }

        public ProjectSettingsWindow()
        {
            InitializeComponent();
            ViewModel = Ioc.Default.GetRequiredService<ProjectSettingsViewModel>();

        }

        private void OnApplyButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

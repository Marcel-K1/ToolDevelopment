using CommunityToolkit.Mvvm.DependencyInjection;
using LevelEditor.Services;
using LevelEditor.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            ServiceCollection services = new ServiceCollection();
            services.AddSingleton(this);
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<PreferencesViewModel>();
            services.AddSingleton<ProjectSettingsViewModel>();
            services.AddSingleton<TileViewModel>();


            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }

    }
}

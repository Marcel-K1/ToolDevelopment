using CommunityToolkit.Mvvm.DependencyInjection;
using LevelEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    public class ViewModelLocator
    {
        private readonly Ioc Locator;

        public ViewModelLocator()
        {
            Locator = Ioc.Default;
        }

        public MainViewModel MainViewModel => Locator.GetRequiredService<MainViewModel>();
        public ProjectSettingsViewModel ProjectSettingsViewModel => Locator.GetRequiredService<ProjectSettingsViewModel>();
        public PreferencesViewModel PreferencesViewModel => Locator.GetRequiredService<PreferencesViewModel>();
        public TileViewModel TileViewModel => Locator.GetRequiredService<TileViewModel>();

    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LevelEditor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        //private readonly IAlerter alerter;
        //public MainViewModel(IAlerter alerter)
        //{
        //    this.alerter = alerter;
        //    ShowMessage = new RelayCommand(OnShowMessage, CanShowMessage);
        //}

        //public RelayCommand ShowMessage { get; }

        //private bool CanShowMessage() => true;

        //private void OnShowMessage() => alerter.Dialog(null, "Closing Level-Editor", "Do you really want to close the application?");
    }
}

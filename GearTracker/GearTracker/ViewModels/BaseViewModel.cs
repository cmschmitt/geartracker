using GearTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GearTracker.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        protected INavigator _navigator;
        //protected IDialogService _dialogService;
        public string Name { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

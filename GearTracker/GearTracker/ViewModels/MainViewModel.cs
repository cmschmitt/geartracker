using GearTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GearTracker.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand GoToLogin
        {
            get
            {
                return new Command(() =>
                {
                    _navigator.PushAsync<LoginViewModel>();
                });
            }
        }

        public ICommand ViewList
        {
            get
            {
                return new Command(() =>
                {
                    _navigator.PushAsync<GearListViewModel>();
                });
            }
        }
    }
}

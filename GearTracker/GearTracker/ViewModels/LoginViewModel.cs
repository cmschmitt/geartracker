using GearTracker.DataAccess.Entities;
using GearTracker.Interfaces;
using GearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GearTracker.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private User _user { get; set; }
        private GearTrackingService _gearTrackingService;
        public LoginViewModel(User user, INavigator navigator, IDialogService dialogService, GearTrackingService gearTrackingService)
        {
            Name = "Login";
            _navigator = navigator;
            _dialogService = dialogService;
            _gearTrackingService = gearTrackingService;
        }
        public ICommand ValidateLogin
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                    {
                        _dialogService.ShowDialogAsync("Must enter your username and password.");
                    }
                    else
                    {
                        _user = await _gearTrackingService.GetUserAsync(UserName, Password);
                        if(_user == null)
                        {
                            _dialogService.ShowDialogAsync("Invalid username and password.");
                            UserName = null;
                            Password = null;
                            NotifyPropertyChanged("");
                        }
                        else
                        {
                            await _navigator.PushAsync<GearListViewModel>();
                        }
                    }
                });
            }
        }
    }
}

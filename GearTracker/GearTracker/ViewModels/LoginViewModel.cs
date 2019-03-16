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
        //TODO:Remove default username and password.
        private User _user { get; set; }
        private GearTrackingService _gearTrackingService;
        private IViewFactory _viewFactory;


        public string UserName { get; set; } = "johndoe";
        public string Password { get; set; } = "password";


        public LoginViewModel(User user, IDialogService dialogService, GearTrackingService gearTrackingService, IViewFactory viewFactory)
        {
            Name = "Login";
            _dialogService = dialogService;
            _gearTrackingService = gearTrackingService;
            _user = user;
            _viewFactory = viewFactory;
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
                        var user = await _gearTrackingService.GetUserAsync(UserName, Password);
                        if(user == null)
                        {
                            _dialogService.ShowDialogAsync("Invalid username and password.");
                            UserName = null;
                            Password = null;
                            NotifyPropertyChanged("");
                        }
                        else
                        {
                            //Update User singleton before creating new instance of MainDetailViewModel
                            _user.Id = user.Id;
                            _user.Name = user.Name;
                            _user.Password = user.Password;
                            ((MasterDetailPage)Application.Current.MainPage).Detail = new NavigationPage(_viewFactory.Resolve<MainDetailViewModel>());
                        }
                    }
                });
            }
        }
    }
}

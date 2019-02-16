using GearTracker.Interfaces;
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
        public LoginViewModel(INavigator navigator) //, IDialogService dialogService
        {
            Name = "Login";
            _navigator = navigator;
            //_dialogService = dialogService;
        }
        public ICommand ValidateLogin
        {
            get
            {
                return new Command(() =>
                {
                    if(string.IsNullOrEmpty(UserName))
                    {
                        //_dialogService.ShowDialogAsync("Must enter your username.");
                    }
                    if (string.IsNullOrEmpty(Password))
                    {
                        //_dialogService.ShowDialogAsync("Must enter your password.");
                    }
                });
            }
        }
    }
}

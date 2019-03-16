using GearTracker.DataAccess.Entities;
using GearTracker.Interfaces;
using GearTracker.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GearTracker.ViewModels
{
    public class MainMasterViewModel : BaseViewModel
    {
        public ObservableCollection<MainMenuItem> MenuItems { get; set; }
        public MainMenuItem SelectedPage { get; set; }
        private IViewFactory _viewFactory;
        public MainMasterViewModel(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            MenuItems = new ObservableCollection<MainMenuItem>(new[]
            {
                    new MainMenuItem { Id = 0, Title = "Home", TargetType=typeof(MainViewModel) },
                    new MainMenuItem { Id = 1, Title = "Gear List", TargetType=typeof(GearListViewModel) }
                });
            NotifyPropertyChanged();
        }

        public ICommand NavigateToPage
        {
            get
            {
                return new Command(() =>
                {
                    var masterPage = Application.Current.MainPage as MasterDetailPage;
                    if (SelectedPage.TargetType == typeof(GearListViewModel))
                        masterPage.Detail = new NavigationPage(_viewFactory.Resolve<GearListViewModel>());
                    if (SelectedPage.TargetType == typeof(MainViewModel))
                        masterPage.Detail = new NavigationPage(_viewFactory.Resolve<MainDetailViewModel>());
                });
            }
        }
    }
}

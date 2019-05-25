using Autofac;
using Autofac.Core;
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
    public class GearListViewModel : BaseViewModel
    {
        private GearTrackingService _gearTrackingService;
        private User _user;
        private IViewFactory _viewFactory;

        public List<Item> Items { get; set; }
        public bool IsLoading { get; set; }
        public Item CurrentItem { get; set; }

        public GearListViewModel(User user, GearTrackingService gearTrackingService, IViewFactory viewFactory)
        {
            Name = "GearList";
            _gearTrackingService = gearTrackingService;
            _user = user;
            _viewFactory = viewFactory;
            //IsLoading = true;
            //NotifyPropertyChanged("IsLoading");
            LoadItems();
        }

        public ICommand LoadHistoriesCommand
        {
            get
            {
                return new Command<Item>(i =>
                {
                    var parameters = new List<Parameter> { new NamedParameter("item", i) };
                    var masterPage = Application.Current.MainPage as MasterDetailPage;
                    masterPage.Detail = new NavigationPage(_viewFactory.ResolveWithParameters<TrackingHistoryListViewModel>(parameters));
                });
            }
        }

        private async void LoadItems()
        {
            try
            {
                Items = await _gearTrackingService.GetUserItemsAsync(_user.Id);
                IsLoading = false;
                NotifyPropertyChanged("IsLoading");
                NotifyPropertyChanged("Items");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

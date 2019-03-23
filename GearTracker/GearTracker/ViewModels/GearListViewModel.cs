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

        public List<ItemViewModel> Items { get; set; }
        public bool IsLoading { get; set; }


        public GearListViewModel(User user, GearTrackingService gearTrackingService)
        {
            Name = "GearList";
            _gearTrackingService = gearTrackingService;
            _user = user;
            //IsLoading = true;
            //NotifyPropertyChanged("IsLoading");
            LoadItems();
        }

        public ICommand LoadItemsCommand
        {
            get
            {
                return new Command(() =>
                {
                    LoadItems();
                });
            }
        }

        private async void LoadItems()
        {
            try
            {
                var items = await _gearTrackingService.GetUserItemsAsync(_user.Id);
                Items = new List<ItemViewModel>();
                foreach (var i in items)
                {
                    Items.Add(new ItemViewModel(i));
                }
                //IsLoading = false;
                //NotifyPropertyChanged("IsLoading");
                NotifyPropertyChanged("Items");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

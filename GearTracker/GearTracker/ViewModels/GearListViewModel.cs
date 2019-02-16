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
        public List<DataAccess.Entities.Item> Items { get; set; }
        public bool IsLoading { get; set; }
        private GearTrackingService _gearTrackingService;
        public GearListViewModel(INavigator navigator, GearTrackingService gearTrackingService)//, IDialogService dialogService
        {
            Name = "GearList";
            _navigator = navigator;
            _gearTrackingService = gearTrackingService;
            //_dialogService = dialogService;
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
                IsLoading = true;
                NotifyPropertyChanged("IsLoading");
                Items = await _gearTrackingService.GetItemsAsync();
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

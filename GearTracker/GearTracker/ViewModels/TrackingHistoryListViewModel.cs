using GearTracker.DataAccess.Entities;
using GearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.ViewModels
{
    public class TrackingHistoryListViewModel : BaseViewModel
    {
        private Item _item;
        private GearTrackingService _gearTrackingService;

        public string ItemName { get; set; }
        public List<TrackingHistory> TrackingHistories { get; set; }

        public TrackingHistoryListViewModel(Item item, GearTrackingService gearTrackingService)
        {
            _gearTrackingService = gearTrackingService;
            _item = item;
            Task.Run(() => LoadHistory());
        }

        public async void LoadHistory()
        {
            TrackingHistories = await _gearTrackingService.GetHistoriesByItemId(_item.Id);
            NotifyPropertyChanged(nameof(TrackingHistories));
        }
    }
}

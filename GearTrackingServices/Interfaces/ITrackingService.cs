using GearTrackerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTrackerServices.Interfaces
{
    public interface ITrackingService
    {
        IEnumerable<GearTrackerData.Models.Action> GetActions();
        IEnumerable<Item> GetItems();
        IEnumerable<Location> GetLocations();
        IEnumerable<TrackingHistory> GetTrackingHistories();
        void CheckInOutItem(string rfidItem, string rfidLocation, DateTime checkInOutTime, int actionId);
        Location GetCurrentItemLocation(Item item);
        IEnumerable<TrackingHistory> GetAllTrackingHistoryForItem(Item item);
        Item GetItem(string rfid);
        Location GetLocation(string rfid);
        TrackingHistory GetLatestTrackingHistoryForItem(string rfid);
    }
}

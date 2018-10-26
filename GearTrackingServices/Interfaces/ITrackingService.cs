using GearTrackerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTrackerServices.Interfaces
{
    public interface ITrackingService
    {
        IEnumerable<Item> GetItems();
        IEnumerable<Location> GetLocations();
        IEnumerable<TrackingHistory> GetTrackingHistories();
        void CheckInOutItem(string rfidItem, string rfidLocation, DateTime checkInOutTime, string action);
        Location GetCurrentItemLocation(Item item);
        IEnumerable<TrackingHistory> GetAllTrackingHistoryForItem(string rfidItem);
        Item GetItem(string rfid);
        Location GetLocation(string rfid);
        TrackingHistory GetLatestTrackingHistoryForItem(string rfid);
    }
}

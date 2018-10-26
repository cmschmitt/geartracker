using GearTrackerData.Implementations;
using GearTrackerData.Models;
using GearTrackerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GearTrackerServices
{
    public class TrackingService : ITrackingService
    {
        private UnitOfWork _unitOfWork;
        public TrackingService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CheckInOutItem(string rfidItem, string rfidLocation, DateTime checkInTime, string action)
        {
            var item = GetItem(rfidItem);
            var location = GetLocation(rfidLocation);
            if(item != null && location != null)
            {
                var newTrackingHistory = new TrackingHistory
                {
                    Date = checkInTime,
                    ItemId = item.Id,
                    LocationId = location.Id,
                    Action = action
                };
                _unitOfWork.TrackingHistoryRepository.Add(newTrackingHistory);
            }
        }

        public Location GetLocation(string rfidLocation)
        {
            try
            {
                var location = _unitOfWork.LocationRepository.Find(i => i.Rfid == rfidLocation).FirstOrDefault();
                if (location == null)
                {
                    throw new Exception("Location not found!");
                }
                return location;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Item GetItem(string rfid)
        {
            try
            {
                var item = _unitOfWork.ItemRepository.Find(i => i.Rfid == rfid).FirstOrDefault();
                if (item == null)
                {
                    throw new Exception("Item not found!");
                }
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Location GetCurrentItemLocation(Item item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            return _unitOfWork.ItemRepository.GetAll();
        }

        public IEnumerable<Location> GetLocations()
        {
            return _unitOfWork.LocationRepository.GetAll();
        }

        public IEnumerable<TrackingHistory> GetTrackingHistories()
        {
            return _unitOfWork.TrackingHistoryRepository.GetAll();
        }

        public IEnumerable<TrackingHistory> GetAllTrackingHistoryForItem(string rfidItem)
        {
            throw new NotImplementedException();
        }

        public TrackingHistory GetLatestTrackingHistoryForItem(string rfid)
        {
            throw new NotImplementedException();
        }
    }
}

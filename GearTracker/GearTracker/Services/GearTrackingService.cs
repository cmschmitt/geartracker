﻿using GearTracker.DataAccess;
using GearTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.Services
{
    public class GearTrackingService
    {
        private GearTrackingContext _gearTrackingContext;
        public GearTrackingService(GearTrackingContext gearTrackingContext)
        {
            _gearTrackingContext = gearTrackingContext;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _gearTrackingContext.Items.GetAll();
        }

        public async Task<List<Item>> GetUserItemsAsync(int userId)
        {
            return await _gearTrackingContext.Items.Find(i => i.UserId == userId);
        }

        public async Task<User> GetUserAsync(string userName, string password)
        {
            return await _gearTrackingContext.Users.FindSingle(u => u.Name == userName && u.Password == password);
        }

        public async Task<List<TrackingHistory>> GetHistoriesByItemId(int itemId)
        {
            var test = await _gearTrackingContext.TrackingHistories.Find(h => h.ItemId == itemId);
            return test;
        }
    }
}

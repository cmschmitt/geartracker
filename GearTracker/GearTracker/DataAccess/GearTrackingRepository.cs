using GearTracker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GearTracker.DataAccess.Entities;
using SQLite;
using System.Threading.Tasks;

namespace GearTracker.DataAccess
{
    public class GearTrackingRepository : IGearTrackingRepository
    {
        private SQLiteAsyncConnection _dbConnection;
        public GearTrackingRepository(string dbPath)
        {
            //object locker = new object(); // class level private field
            //                              // rest of class code
            //lock (locker)
            //{
            //    // Do your query or insert here
            //}
            bool createDatabase = !File.Exists(dbPath);
            _dbConnection = new SQLiteAsyncConnection(dbPath);
            if (createDatabase)
                CreateDatabase();
        }

        private void CreateDatabase()
        {
            try
            {
                _dbConnection.CreateTablesAsync<Item, TrackingAction, TrackingHistory>();
                var items = new List<Item>
                {
                    new Item
                    {
                        Id = 1,
                        Name = "SM57"
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "SM58"
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "RC-30"
                    },
                    new Item
                    {
                        Id = 4,
                        Name = "UMC404HD"
                    }
                };
                var actions = new List<TrackingAction>
                {
                    new TrackingAction
                    {
                        Id = 1,
                        Name = "Check In"
                    },
                    new TrackingAction
                    {
                        Id = 2,
                        Name = "Check Out"
                    }
                };
                var histories = new List<TrackingHistory>
                {
                    new TrackingHistory
                    {
                        Id = 1,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 1,
                        TrackingActionId = 1,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 2,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 2,
                        TrackingActionId = 1,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 3,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 3,
                        TrackingActionId = 1,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 4,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 4,
                        TrackingActionId = 1,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 5,
                        Date = DateTime.Now,
                        ItemId = 1,
                        TrackingActionId = 2,
                        Location = "1234 Some St, Cape Girardeau, MO 63701"
                    }
                };
                _dbConnection.InsertAllAsync(items);
                _dbConnection.InsertAllAsync(actions);
                _dbConnection.InsertAllAsync(histories);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Queries

        public async Task<List<Item>> GetItemsAsync()
        {
            var result = await _dbConnection.QueryAsync<Item>("SELECT * FROM Item");
            return result;
        }

        public async Task<List<TrackingAction>> GetTrackingActionsAsync()
        {
            var result = await _dbConnection.QueryAsync<TrackingAction>("SELECT * FROM TrackingAction");
            return result;
        }

        public async Task<List<TrackingHistory>> GetTrackingHistoriesAsync()
        {
            var result = await _dbConnection.QueryAsync<TrackingHistory>("SELECT * FROM TrackingHistory");
            return result;
        }


        #endregion
    }
}

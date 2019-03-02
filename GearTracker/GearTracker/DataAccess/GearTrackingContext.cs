using GearTracker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GearTracker.DataAccess.Entities;
using SQLite;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GearTracker.DataAccess
{
    public class GearTrackingContext
    {
        private SQLiteAsyncConnection _dbConnection;

        public Repository<Item> Items { get; set; }
        public Repository<TrackingHistory> TrackingHistories { get; set; }

        public GearTrackingContext(string dbPath)
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
            Items = new Repository<Item>(_dbConnection);
            TrackingHistories = new Repository<TrackingHistory>(_dbConnection);
        }

        private void CreateDatabase()
        {
            try
            {
                _dbConnection.CreateTablesAsync<Item, TrackingHistory>();
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
                var histories = new List<TrackingHistory>
                {
                    new TrackingHistory
                    {
                        Id = 1,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 1,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 2,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 2,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 3,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 3,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 4,
                        Date = DateTime.Now.AddDays(-1),
                        ItemId = 4,
                        Location = "Home"
                    },
                    new TrackingHistory
                    {
                        Id = 5,
                        Date = DateTime.Now,
                        ItemId = 1,
                        Location = "1234 Some St, Cape Girardeau, MO 63701"
                    }
                };
                _dbConnection.InsertAllAsync(items);
                _dbConnection.InsertAllAsync(histories);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

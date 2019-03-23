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
        public Repository<User> Users { get; set; }

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
#if DEBUG
            if (!createDatabase)
            {
                File.Delete(dbPath);
                CreateDatabase();
            }
#endif
            Items = new Repository<Item>(_dbConnection);
            TrackingHistories = new Repository<TrackingHistory>(_dbConnection);
            Users = new Repository<User>(_dbConnection);
        }

        private async void CreateDatabase()
        {
            try
            {
                var users = new List<User> { new User { Id = 1, Name = "johndoe", Password = "password" } };
                await _dbConnection.CreateTablesAsync<Item, TrackingHistory, User>();
                var items = new List<Item>
                {
                    new Item
                    {
                        Id = 1,
                        Name = "SM57",
                        UserId = 1
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "SM58",
                        UserId = 1
                    },
                    new Item
                    {
                        Id = 3,
                        Name = "RC-30",
                        UserId = 1
                    },
                    new Item
                    {
                        Id = 4,
                        Name = "UMC404HD",
                        UserId = 1
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
                        Location = "1234 Some St, Somewhere, CA 61234"
                    }
                };
                await _dbConnection.InsertAllAsync(users);
                await _dbConnection.InsertAllAsync(items);
                await _dbConnection.InsertAllAsync(histories);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

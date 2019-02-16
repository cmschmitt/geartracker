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
                _dbConnection.CreateTableAsync<Item>();
                var items = new List<Item>
                {
                    new Item
                    {
                        Name = "SM57",
                        CheckedIn = false
                    },
                    new Item
                    {
                        Name = "SM58",
                        CheckedIn = false
                    },
                    new Item
                    {
                        Name = "RC-30",
                        CheckedIn = true
                    },
                    new Item
                    {
                        Name = "UMC404HD",
                        CheckedIn = false
                    }
                };
                _dbConnection.InsertAllAsync(items);
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

        #endregion
    }
}

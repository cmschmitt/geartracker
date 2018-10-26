using GearTrackerData.Interfaces;
using GearTrackerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTrackerData.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly GearTrackingContext _context;
        private IRepository<Item> _itemRepository;
        private IRepository<Location> _locationRepository;
        private IRepository<TrackingHistory> _trackingHistoryRepository;
        private bool disposed = false;

        public UnitOfWork(GearTrackingContext context)
        {
            _context = context;
        }
        

        public IRepository<Item> ItemRepository
        {
            get
            {
                return _itemRepository ?? new Repository<Item>(_context);
            }
        }
        public IRepository<Location> LocationRepository
        {
            get
            {
                return _locationRepository ?? new Repository<Location>(_context);
            }
        }
        public IRepository<TrackingHistory> TrackingHistoryRepository
        {
            get
            {
                return _trackingHistoryRepository ?? new Repository<TrackingHistory>(_context);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using GearTracker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGearTrackingRepository GearTrackingRepository { get; set; }

        public UnitOfWork(IGearTrackingRepository gearTrackingRepository)
        {
            GearTrackingRepository = gearTrackingRepository;
        }
    }
}

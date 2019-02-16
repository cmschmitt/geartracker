using GearTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.DataAccess.Interfaces
{
    public interface IGearTrackingRepository
    {
        Task<List<Item>> GetItemsAsync();
    }
}

using GearTracker.DataAccess;
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
            var result = await _gearTrackingContext.Items.GetAll();
            return result;
        }
    }
}

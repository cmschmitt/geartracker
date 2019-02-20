using GearTracker.DataAccess.Entities;
using GearTracker.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.Services
{
    public class GearTrackingService
    {
        private IUnitOfWork _unitOfWork;

        public GearTrackingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            var result = await _unitOfWork.GearTrackingRepository.GetItemsAsync();
            return result;
        }
    }
}

using GearTrackerData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTrackerData.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<Item>
        int Complete();
    }
}

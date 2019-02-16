using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IGearTrackingRepository GearTrackingRepository { get; set; }
        //Func<TransactionScope> BeginTransaction { get; set; }
    }
}

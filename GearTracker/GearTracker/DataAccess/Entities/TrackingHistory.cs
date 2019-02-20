using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.DataAccess.Entities
{
    public class TrackingHistory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int TrackingActionId { get; set; }
    }
}

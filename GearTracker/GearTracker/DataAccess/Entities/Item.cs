using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.DataAccess.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Rfid { get; set; }
        //public List<TrackingHistory> TrackingHistories { get; set; }
    }
}


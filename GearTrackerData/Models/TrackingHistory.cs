using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearTrackerData.Models
{
    public class TrackingHistory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public string Action { get; set; }
    }
}

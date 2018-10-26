using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearTrackerData.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rfid { get; set; }
    }
}

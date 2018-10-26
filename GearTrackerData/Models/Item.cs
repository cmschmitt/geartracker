using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearTrackerData.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rfid { get; set; }
    }
}

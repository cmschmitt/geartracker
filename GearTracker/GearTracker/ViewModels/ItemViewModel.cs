using System;
using System.Collections.Generic;
using System.Text;
using GearTracker.DataAccess.Entities;

namespace GearTracker.ViewModels
{
    public class ItemViewModel
    {
        private Item _item;

        public int Id
        {
            get { return _item.Id; }
            set { _item.Id = value; }
        }
        public int UserId
        {
            get { return _item.UserId; }
            set { _item.UserId = value; }
        }
        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }
        public string Rfid
        {
            get { return _item.Rfid; }
            set { _item.Rfid = value; }
        }
        public List<string> TrackingHistories { get; set; } = new List<string> { "aldjkf" };
        public bool IsHistoryVisible { get; set; } = true;

        public ItemViewModel(Item item)
        {
            _item = item;
        }
    }
}

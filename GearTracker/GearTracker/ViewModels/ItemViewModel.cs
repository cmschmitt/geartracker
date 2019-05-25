using System;
using System.Collections.Generic;
using System.Text;
using GearTracker.DataAccess.Entities;

namespace GearTracker.ViewModels
{
    public class ItemViewModel
    {
        //public string Name { get; set; }
        
        //public List<string> History { get; set; }

        //public ItemViewModel(string name, List<string> history)
        //{
        //    Name = name;
        //    History = history;
        //}

        //public static List<ItemViewModel> GetList()
        //{
        //    var l = new List<ItemViewModel>();
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    l.Add(new ItemViewModel("SM57", new List<string> { "test1", "test2" }));
        //    return l;
        //}
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
        public List<TrackingHistory> TrackingHistories { get; set; }
        public bool IsHistoryVisible { get; set; } = true;

        public ItemViewModel(Item item)
        {
            _item = item;
        }
    }
}

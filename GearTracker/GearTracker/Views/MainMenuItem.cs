using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.Views
{

    public class MainMenuItem
    {
        public MainMenuItem()
        {
            TargetType = typeof(MainDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
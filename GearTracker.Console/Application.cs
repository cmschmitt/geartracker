using GearTracker.ConsoleApp.Interfaces;
using GearTrackerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.ConsoleApp
{
    public class Application : IApplication
    {
        ITrackingService _trackingService;
        public Application(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        public void Run()
        {
            var list = _trackingService.GetItems();
            foreach (var l in list)
            {
                Console.WriteLine($"{l.Name}{Environment.NewLine}");
            }
            
        }
    }
}

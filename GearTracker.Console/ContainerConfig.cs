using Autofac;
using GearTracker.ConsoleApp.Interfaces;
using GearTrackerData.Implementations;
using GearTrackerData.Interfaces;
using GearTrackerServices;
using GearTrackerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.ConsoleApp
{
    public static class ContainerConfig
    {
        //private readonly string connectionString = "Data Source=.,1433;Initial Catalog=GearTracking;Integrated Security=True";
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<TrackingService>().As<ITrackingService>();
            builder.RegisterType<UnitOfWork>();
            builder.RegisterType<GearTrackingContext>();
            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(GearTrackerServices)))
            //    .Where(t => t.Namespace == nameof(GearTrackerServices.Interfaces))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"));

            return builder.Build();
        }
    }
}

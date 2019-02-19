using Autofac;
using GearTracker.Bootstrapping.Modules;
using GearTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GearTracker.Bootstrapping
{
    public abstract class AutofacBootstrapper
    {
        public void Run(ContainerBuilder builder)
        {
            ConfigureContainer(builder);
            var container = builder.Build();
            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(container);
        }
        /// <summary>
        /// This method iterates through dictionary of mapped types
        /// and registers each type with the container builder. Then 
        /// it registers the GearTrackerAutofacModule with is responsible
        /// for registering the ViewFactory and Navigator types.
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<GearTrackerAutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory viewFactory);
        protected abstract void ConfigureApplication(IContainer container);
    }
}

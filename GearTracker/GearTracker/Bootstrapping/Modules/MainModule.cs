using Autofac;
using GearTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.Bootstrapping.Modules
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainView>().SingleInstance();
            builder.RegisterType<MainViewModel>().SingleInstance();
        }
    }
}

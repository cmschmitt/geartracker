using Autofac;
using GearTracker.Interfaces;
using GearTracker.ViewModels;
using GearTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;


namespace GearTracker.Bootstrapping.Modules
{
    public class GearListModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GearListView>().SingleInstance();
            builder.RegisterType<GearListViewModel>().SingleInstance();

        }
    }
}

using Autofac;
using GearTracker.Interfaces;
using GearTracker.ViewModels;
using GearTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.Bootstrapping.Modules
{
    public class LoginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginView>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            
        }
    }
}

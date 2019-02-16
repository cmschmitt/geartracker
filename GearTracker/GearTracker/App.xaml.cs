using Autofac;
using GearTracker.Services;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GearTracker.Bootstrapping;
using System.Collections.Generic;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GearTracker
{
	public partial class App : Application
	{
		public App ()
		{
            //Entry point for application.
			InitializeComponent();
            var bootstrapper = new Bootstrapper(this);
            Dictionary<Type, Type> mappedTypes = new Dictionary<Type, Type>();
            bootstrapper.RunWithMappedTypes(mappedTypes);
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
		}

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

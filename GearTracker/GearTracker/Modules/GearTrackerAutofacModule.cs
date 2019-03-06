using Autofac;
using GearTracker.DataAccess;
using GearTracker.DataAccess.Entities;
using GearTracker.DataAccess.Interfaces;
using GearTracker.Factories;
using GearTracker.Interfaces;
using GearTracker.Services;
using GearTracker.ViewModels;
using GearTracker.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace GearTracker.Modules
{
    public class GearTrackerAutofacModule : Autofac.Module
    {
        /// <summary>
        /// Register the ViewFactory and Navigator types.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var sqliteFilename = "GearTracking.db3";
#if __ANDROID__
            // Just use whatever directory SpecialFolder.Personal returns
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#else
// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
// (they don't want non-user-generated data in Documents)
string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder instead
#endif
            var dbPath = Path.Combine(libraryPath, sqliteFilename);
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<GearTrackingContext>().WithParameter(new TypedParameter(typeof(string), dbPath));
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.RegisterType<GearTrackingService>().SingleInstance();
            builder.Register<INavigation>(context => App.Current.MainPage.Navigation).SingleInstance();
            builder.RegisterType<MainView>().SingleInstance();
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<LoginView>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<GearListView>().SingleInstance();
            builder.RegisterType<GearListViewModel>().SingleInstance();
            //builder.Register(c => c.Resolve<User>());
            builder.RegisterType<User>().SingleInstance();
        }
    }
}

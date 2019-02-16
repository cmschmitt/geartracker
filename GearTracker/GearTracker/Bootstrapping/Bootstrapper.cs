using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using GearTracker.Bootstrapping.Modules;
using GearTracker.Interfaces;
using GearTracker.ViewModels;
using GearTracker.Views;
using Xamarin.Forms;

namespace GearTracker.Bootstrapping
{
    public class Bootstrapper : AutofacBootstrapper
    {
        private App _app;
        public Bootstrapper(App app)
        {
            _app = app;
        }
        /// <summary>
        /// This registers all the modules need for the application.
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<MainModule>();
            builder.RegisterModule<LoginModule>();
            builder.RegisterModule<GearListModule>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var mainPage = viewFactory.Resolve<MainViewModel>();

            var navPage = new NavigationPage(mainPage);
            _app.MainPage = navPage;
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<MainViewModel, MainView>();
            viewFactory.Register<LoginViewModel, LoginView>();
            viewFactory.Register<GearListViewModel, GearListView>();
        }
    }
}

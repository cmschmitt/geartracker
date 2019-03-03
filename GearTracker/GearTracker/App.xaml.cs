using Autofac;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GearTracker.Modules;
using GearTracker.Interfaces;
using GearTracker.ViewModels;
using GearTracker.Views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GearTracker
{
	public partial class App : Application
	{
        private static IContainer _container;
        public App (ContainerBuilder builder)
		{
            InitializeComponent();
            BuildContainer(builder);
        }

        private void BuildContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<GearTrackerAutofacModule>();
            
            _container = builder.Build();
            var viewFactory = _container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(viewFactory);
        }

        private void ConfigureApplication(IViewFactory viewFactory)
        {
            var mainPage = viewFactory.Resolve<LoginViewModel>();
            var navPage = new NavigationPage(mainPage);
            MainPage = navPage;
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            //viewFactory.Register<MainViewModel, MainView>();
            viewFactory.Register<LoginViewModel, LoginView>();
            viewFactory.Register<GearListViewModel, GearListView>();
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

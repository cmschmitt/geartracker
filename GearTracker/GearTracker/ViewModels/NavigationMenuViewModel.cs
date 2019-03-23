using GearTracker.Extensions;
using GearTracker.Extensions.Events;
using GearTracker.Interfaces;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GearTracker.ViewModels
{
    public class NavigationMenuViewModel : BaseViewModel
    {
        private IViewFactory _viewFactory;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<MainMenuItem> MenuItems { get; set; }
        public MainMenuItem SelectedMenuItem { get; set; }

        public NavigationMenuViewModel(IViewFactory viewFactory, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _viewFactory = viewFactory;
            MenuItems = new ObservableCollection<MainMenuItem>(new[]
            {
                    new MainMenuItem { Id = 0, Title = "Home", TargetType = typeof(MainDetailViewModel) },
                    new MainMenuItem { Id = 1, Title = "Gear List", TargetType = typeof(GearListViewModel) }
                });
            NotifyPropertyChanged();
        }

        public ICommand NavigateToPage
        {
            get
            {
                return new Command(() =>
                {
                    var masterPage = Application.Current.MainPage as MasterDetailPage;
                    var viewFactoryType = _viewFactory.GetType();
                    var resolveMethod = viewFactoryType.GetMethod("Resolve").MakeGenericMethod(SelectedMenuItem.TargetType);
                    masterPage.Detail = new NavigationPage((Page)resolveMethod.Invoke(_viewFactory, null));
                    _eventAggregator.GetEvent<MenuItemSelectedEvent>().Publish();
                });
            }
        }
    }
}

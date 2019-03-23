using GearTracker.Extensions.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GearTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MasterDetailPage
    {
        public MainView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            eventAggregator.GetEvent<MenuItemSelectedEvent>().Subscribe(HideNavigationMenu);
        }

        private void HideNavigationMenu()
        {
            IsPresented = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GearTracker.Interfaces
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>()
            where TViewModel : class, IViewModel
            where TView : Page;

        Page Resolve<TViewModel>()
            where TViewModel : class, IViewModel;
    }
}

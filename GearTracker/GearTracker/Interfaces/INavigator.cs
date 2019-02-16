using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.Interfaces
{
    public interface INavigator
    {
        Task PopAsync();
        Task PopToRootAsync();
        Task PushAsync<TViewModel>()
            where TViewModel : class, IViewModel;
        Task PushModalAsync<TViewModel>()
            where TViewModel : class, IViewModel;
    }
}

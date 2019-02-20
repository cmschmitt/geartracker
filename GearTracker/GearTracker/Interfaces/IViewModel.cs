using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GearTracker.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void NotifyPropertyChanged([CallerMemberName] string propertyName = "");
    }
}

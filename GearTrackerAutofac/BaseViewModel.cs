using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SandboxAutofac
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

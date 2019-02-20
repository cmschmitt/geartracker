using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.Interfaces
{
    public interface IDialogService
    {
        void ShowDialogAsync(string message);
    }
}

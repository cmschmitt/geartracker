using GearTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GearTracker.CustomControls
{
    public class NativeListView : ListView
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create("Items", typeof(IEnumerable<ItemViewModel>), typeof(NativeListView), new List<ItemViewModel>());

        public IEnumerable<ItemViewModel> Items
        {
            get { return (IEnumerable<ItemViewModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        public void NotifyItemSelected(object item)
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, new SelectedItemChangedEventArgs(item));
            }
        }
    }
}

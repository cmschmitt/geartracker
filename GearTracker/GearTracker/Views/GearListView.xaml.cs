using GearTracker.CustomControls;
using GearTracker.ViewModels;
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
	public partial class GearListView : ContentPage
	{
		public GearListView ()
		{
			InitializeComponent();
            //gearListView = new NativeListView
            //{
            //    Items = ItemViewModel.GetList(),
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
        }

	}
}
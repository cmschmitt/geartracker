using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GearTracker.CustomControls;
using GearTracker.ViewModels;

namespace GearTracker.Droid.CustomControls
{
    public class NativeAndroidListViewAdapter : BaseAdapter<ItemViewModel>
    {
        readonly Activity context;
        IList<ItemViewModel> tableItems = new List<ItemViewModel>();

        public IEnumerable<ItemViewModel> Items
        {
            set
            {
                tableItems = value.ToList();
            }
        }

        public NativeAndroidListViewAdapter(Activity context, NativeListView view)
        {
            this.context = context;
            tableItems = view.Items.ToList();
        }

        public override ItemViewModel this[int position]
        {
            get
            {
                return tableItems[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = tableItems[position];

            var view = convertView;
            if (view == null)
            {
                // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.NativeAndroidListViewCell, null);
            }
            //view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Name;
            //view.FindViewById<TextView>(Resource.Id.Text2).Text = item.TrackingHistories.FirstOrDefault();

            //// grab the old image and dispose of it
            //if (view.FindViewById<ImageView>(Resource.Id.Image).Drawable != null)
            //{
            //    using (var image = view.FindViewById<ImageView>(Resource.Id.Image).Drawable as BitmapDrawable)
            //    {
            //        if (image != null)
            //        {
            //            if (image.Bitmap != null)
            //            {
            //                //image.Bitmap.Recycle ();
            //                image.Bitmap.Dispose();
            //            }
            //        }
            //    }
            //}

            //// If a new image is required, display it
            //if (!String.IsNullOrWhiteSpace(item.ImageFilename))
            //{
            //    context.Resources.GetBitmapAsync(item.ImageFilename).ContinueWith((t) => {
            //        var bitmap = t.Result;
            //        if (bitmap != null)
            //        {
            //            view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap);
            //            bitmap.Dispose();
            //        }
            //    }, TaskScheduler.FromCurrentSynchronizationContext());
            //}
            //else
            //{
            //    // clear the image
            //    view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(null);
            //}

            return view;
        }
    }
}
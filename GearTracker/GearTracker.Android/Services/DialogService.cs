using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GearTracker.Interfaces;
using Xamarin.Forms;

namespace GearTracker.Droid.Services
{
    public class DialogService : IDialogService
    {
        public void ShowDialogAsync(string message)
        {
            try
            {
                //TODO: figure out how to get Application.Context to work here.
                AlertDialog.Builder alert = new AlertDialog.Builder(Forms.Context);
                alert.SetTitle(message);
                alert.SetNeutralButton("OK", (senderAlert, args) =>
                {

                });
                
                alert.Show();
                //await Task.Yield();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}
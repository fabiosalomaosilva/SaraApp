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

namespace SaraApp.Droid
{
    [Activity(Label = "SARA", Icon = "@drawable/Icon", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}
using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ProntuarioApp.Droid
{
    [Activity(Label = "ProntuarioApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //protected override void OnCreate(Bundle bundle)
        //{

        //    ToolbarResource = Resource.Layout.Toolbar;
        //    TabLayoutResource = Resource.Layout.Tabbar;
        //    base.OnCreate(bundle);
        //    Forms.Init(this, bundle);
        //    LoadApplication(new App());

        //    TabLayoutResource = Resource.Layout.Tabbar;
        //    ToolbarResource = Resource.Layout.Toolbar;

        //    base.OnCreate(savedInstanceState);

        //    global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
        //    global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
        //    LoadApplication(new App());


        //}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}
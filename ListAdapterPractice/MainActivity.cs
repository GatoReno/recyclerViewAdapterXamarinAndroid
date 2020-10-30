using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ListAdapterPractice.Models;
using ListAdapterPractice.Resources.DataSource;

namespace ListAdapterPractice
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        RecyclerView _contctsRecycleView;
        IList<Contact> _constactsSource = new List<Contact>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            _contctsRecycleView = (RecyclerView)FindViewById(Resource.Id.recyclerContacts);
            SetUpRecyclerView();
        }

        private void SetUpRecyclerView()
        {
            _constactsSource.Clear();
            _contctsRecycleView.HasFixedSize = true;
            Contact c1 = new Contact()
            {
                Email = "yeah@y.com",
                Password = "1111111"
            };
            Contact c11 = new Contact()
            {
                Email = "yzeah@y.com",
                Password = "111zz111z1"
            };
            _constactsSource.Add(c1); _constactsSource.Add(c11);
            _contctsRecycleView
               .SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(_contctsRecycleView.Context));
            RecyclerViewAdapterContacts adapter = new RecyclerViewAdapterContacts(_constactsSource);
            //adapter.ItemClick += OnLonClick; //attach method 
            _contctsRecycleView.SetAdapter(adapter);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

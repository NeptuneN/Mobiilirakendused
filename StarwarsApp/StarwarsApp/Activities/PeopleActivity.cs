using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using StarwarsApp.Adapters;
using StarwarsApp.Models;
using StarwarsApp.Services;

namespace StarwarsApp.Activities
{
    [Activity(Label = "PeopleActivity")]
    public class PeopleActivity : Activity
    {
        People dataPeople = new People();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.people_layout);

            var remoteDataService = new RemoteDataService();
            dataPeople = await remoteDataService.GetStarwarsPeople();

            var listViewPeople = FindViewById<ListView>(Resource.Id.listViewPeople);
            listViewPeople.Adapter = new PeopleAdapter(this, dataPeople.results);
            listViewPeople.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowClick = e.Position;

            var t = dataPeople.results[rowClick];

            var intent = new Intent(this, typeof(PeopleDetailActivity));
            intent.PutExtra("People", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}
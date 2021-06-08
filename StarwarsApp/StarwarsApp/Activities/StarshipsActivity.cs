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
    [Activity(Label = "StarshipsActivity")]
    public class StarshipsActivity : Activity
    {
        Starships dataStarships = new Starships();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.starships_layout);

            var remoteDataService = new RemoteDataService();
            dataStarships = await remoteDataService.GetStarwarsStarships();

            var listViewStarships = FindViewById<ListView>(Resource.Id.listViewStarships);
            listViewStarships.Adapter = new StarshipsAdapter(this, dataStarships.results);
            listViewStarships.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowClick = e.Position;

            var t = dataStarships.results[rowClick];

            var intent = new Intent(this, typeof(StarshipsDetailActivity));
            intent.PutExtra("Starships", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}
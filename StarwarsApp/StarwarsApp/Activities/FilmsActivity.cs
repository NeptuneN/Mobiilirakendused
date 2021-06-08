using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Adapters;
using StarwarsApp.Models;
using StarwarsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp.Activities
{
    [Activity(Label = "FilmsActivity")]
    public class FilmsActivity : Activity
    {
        Films dataFilms = new Films();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.films_layout);

            var remoteDataService = new RemoteDataService();
            dataFilms = await remoteDataService.GetStarwarsFilms();

            var listViewFilms = FindViewById<ListView>(Resource.Id.listViewFilms);
            listViewFilms.Adapter = new FilmsAdapter(this, dataFilms.results);
            listViewFilms.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowClick = e.Position;

            var t = dataFilms.results[rowClick];

            var intent = new Intent(this, typeof(FilmsDetailActivity));
            intent.PutExtra("Films", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}
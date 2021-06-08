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
    [Activity(Label = "PlanetsActivity")]
    public class PlanetsActivity : Activity
    {
        Planets dataPlanets = new Planets();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.planets_layout);

            var remoteDataService = new RemoteDataService();
            dataPlanets = await remoteDataService.GetStarwarsPlanets();

            var listViewPlanets = FindViewById<ListView>(Resource.Id.listViewPlanets);
            listViewPlanets.Adapter = new PlanetsAdapter(this, dataPlanets.results);
            listViewPlanets.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowClick = e.Position;

            var t = dataPlanets.results[rowClick];

            var intent = new Intent(this, typeof(PlanetsDetailActivity));
            intent.PutExtra("Planets", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}
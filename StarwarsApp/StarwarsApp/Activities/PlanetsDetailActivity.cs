using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp.Activities
{
    [Activity(Label = "PlanetsDetailActivity")]
    public class PlanetsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.planets_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextview);
            var rotation_periodText = FindViewById<TextView>(Resource.Id.rotation_periodTextview);
            var orbital_periodText = FindViewById<TextView>(Resource.Id.orbital_periodTextview);
            var diameterText = FindViewById<TextView>(Resource.Id.diameterTextview);
            var climateText = FindViewById<TextView>(Resource.Id.climateTextview);
            var gravityText = FindViewById<TextView>(Resource.Id.gravityTextview);
            var terrainText = FindViewById<TextView>(Resource.Id.terrainTextview);

            var planetsDetailInJson = Intent.GetStringExtra("PlanetsDetail");
            var details = JsonConvert.DeserializeObject<PlanetsDetails>(planetsDetailInJson);

            nameText.Text = details.name;
            rotation_periodText.Text = details.rotation_period;
            orbital_periodText.Text = details.orbital_period;
            diameterText.Text = details.diameter;
            climateText.Text = details.climate;
            gravityText.Text = details.gravity;
            terrainText.Text = details.terrain;
        }
    }
}
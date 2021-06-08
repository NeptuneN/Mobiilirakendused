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
    [Activity(Label = "StarshipsDetailActivity")]
    public class StarshipsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.starships_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextview);
            var modelText = FindViewById<TextView>(Resource.Id.modelTextview);
            var manufacturerText = FindViewById<TextView>(Resource.Id.manufacturerTextview);
            var cost_in_creditsText = FindViewById<TextView>(Resource.Id.cost_in_creditsTextview);
            var lengthText = FindViewById<TextView>(Resource.Id.lengthTextview);

            var starshipsDetailInJson = Intent.GetStringExtra("StarshipsDetail");
            var details = JsonConvert.DeserializeObject<StarshipsDetails>(starshipsDetailInJson);

            nameText.Text = details.name;
            modelText.Text = details.model;
            manufacturerText.Text = details.manufacturer;
            cost_in_creditsText.Text = details.cost_in_credits;
            lengthText.Text = details.length;
        }
    }
}
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
    [Activity(Label = "FilmsDetailActivity")]
    public class FilmsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.films_detail_layout);

            var titleText = FindViewById<TextView>(Resource.Id.titleTextview);
            var directorText = FindViewById<TextView>(Resource.Id.directorTextview);
            var producerText = FindViewById<TextView>(Resource.Id.producerTextview);

            var filmsDetailInJson = Intent.GetStringExtra("Films");
            var details = JsonConvert.DeserializeObject<FilmsDetails>(filmsDetailInJson);

            titleText.Text = details.title;
            directorText.Text = details.director;
            producerText.Text = details.producer;
        }
    }
}
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
    [Activity(Label = "PeopleDetailActivity")]
    public class PeopleDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.people_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextview);
            var heightText = FindViewById<TextView>(Resource.Id.heightTextview);
            var massText = FindViewById<TextView>(Resource.Id.massTextview);
            var hair_colorText = FindViewById<TextView>(Resource.Id.hair_colorTextview);
            var skin_colorText = FindViewById<TextView>(Resource.Id.skin_colorTextview);
            var eye_colorText = FindViewById<TextView>(Resource.Id.eye_colorTextview);
            var birth_yearText = FindViewById<TextView>(Resource.Id.birth_yearTextview);
            var genderText = FindViewById<TextView>(Resource.Id.genderTextview);

            var peopleDetailInJson = Intent.GetStringExtra("PeopleDetail");
            var details = JsonConvert.DeserializeObject<PeopleDetails>(peopleDetailInJson);

            nameText.Text = details.name;
            heightText.Text = details.height;
            massText.Text = details.mass;
            hair_colorText.Text = details.hair_color;
            skin_colorText.Text = details.skin_color;
            eye_colorText.Text = details.eye_color;
            birth_yearText.Text = details.birth_year;
            genderText.Text = details.gender;
        }
    }
}
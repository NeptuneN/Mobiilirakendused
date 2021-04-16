using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using StarwarsApp.Models;
using StarwarsApp.Services;
using Android.Content;

namespace StarwarsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            var remoteDataService = new RemoteDataService();
            var PeopleData = await remoteDataService.GetStarwarsPeople();
            var FilmsData = await remoteDataService.GetStarwarsFilms();
            var StarshipsData = await remoteDataService.GetStarwarsStarships();
            var PlanetsData = await remoteDataService.GetStarwarsPlanets();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var buttonFilms = FindViewById<Button>(Resource.Id.buttonFilms);
            buttonFilms.Click += Button_Click_Films;
            var buttonPeople = FindViewById<Button>(Resource.Id.buttonPeople);
            buttonPeople.Click += Button_Click_People;
            var buttonPlanets = FindViewById<Button>(Resource.Id.buttonPlanets);
            buttonPlanets.Click += Button_Click_Planets;
            var buttonStarships = FindViewById<Button>(Resource.Id.buttonStarships);
            buttonStarships.Click += Button_Click_Starships;
        }
        private void Button_Click_Films(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(/*placeholder*/));
            StartActivity(intent);
        }
        private void Button_Click_People(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(/*placeholder*/));
            StartActivity(intent);
        }
        private void Button_Click_Planets(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(/*placeholder*/));
            StartActivity(intent);
        }
        private void Button_Click_Starships(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(/*placeholder*/));
            StartActivity(intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
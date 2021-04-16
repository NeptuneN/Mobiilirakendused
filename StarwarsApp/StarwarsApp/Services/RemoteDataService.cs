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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsApp.Services
{
    public class RemoteDataService
    {
        public async Task<People> GetStarwarsPeople()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/people/");
            People PeopleData = null;
            if(response != null)
            {
                PeopleData = JsonConvert.DeserializeObject<People>(response);
            }
            return PeopleData;         
        }
        public async Task<Films> GetStarwarsFilms()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/films/");
            Films FilmsData = null;
            if(response != null)
            {
                FilmsData = JsonConvert.DeserializeObject<Films>(response);
            }
            return FilmsData;
        }
        public async Task<Starships> GetStarwarsStarships()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/starships/");
            Starships StarshipsData = null;
            if (response != null)
            {
                StarshipsData = JsonConvert.DeserializeObject<Starships>(response);
            }
            return StarshipsData;
        }
        public async Task<Planets> GetStarwarsPlanets()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/planets/");
            Planets PlanetsData = null;
            if (response != null)
            {
                PlanetsData = JsonConvert.DeserializeObject<Planets>(response);
            }
            return PlanetsData;
        }
    }
}
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

namespace StarwarsApp.Models
{
    public class PlanetsDetails
    {
        public string name { get; set; }
        public int rotation_period { get; set; }
        public int orbital_period { get; set; }
        public int diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public int surface_water { get; set; }
        public int population { get; set; }
        public List<string> residents { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
    public class Planets
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PlanetsDetails> results { get; set; }
    }
}
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

namespace Kalkulaator
{
    [Activity(Label = "Kalkulaator")]
    public class Kalkulaator : Activity
    {
        EditText _editNumber1;
        EditText _editNumber2;
        TextView _answerText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_kalkulaator);
            _editNumber1 = FindViewById<EditText>(Resource.Id.editNumber1);
            _editNumber2 = FindViewById<EditText>(Resource.Id.editNumber2);
            var addButton = FindViewById<Button>(Resource.Id.buttonLiida);
            var subButton = FindViewById<Button>(Resource.Id.buttonLahuta);
            var divButton = FindViewById<Button>(Resource.Id.buttonJaga);
            var mulButton = FindViewById<Button>(Resource.Id.buttonKorruta);
            _answerText = FindViewById<TextView>(Resource.Id.vastusEdit);

            addButton.Click += AddButton_Click;
            subButton.Click += SubButton_Click;
            divButton.Click += DivButton_Click;
            mulButton.Click += MulButton_Click;
        }

        private void MulButton_Click(object sender, EventArgs e)
        {
            var answer = double.Parse(_editNumber1.Text) * double.Parse(_editNumber2.Text);
            _answerText.Text = answer.ToString();
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            var answer = double.Parse(_editNumber1.Text) / double.Parse(_editNumber2.Text);
            _answerText.Text = answer.ToString();
        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            var answer = double.Parse(_editNumber1.Text) - double.Parse(_editNumber2.Text);
            _answerText.Text = answer.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var answer = double.Parse(_editNumber1.Text) + double.Parse(_editNumber2.Text);
            _answerText.Text = answer.ToString();
        }
    }
}
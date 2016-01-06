
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Amnesty
{
	[Activity (Label = "ConfirmationActivity")]			
	public class ConfirmationActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Confirmation);

			// Create your application here
			string myText = Intent.GetStringExtra ("firstname") ?? "Data not available";

			var textfield = (TextView) FindViewById(Resource.Id.testView1);
			textfield.Text = myText;

		}
	}
}


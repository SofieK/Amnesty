
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
	[Activity (Label = "ThankyouActivity")]			
	public class ThankyouActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Thankyou);

			Button btnHome = FindViewById<Button> (Resource.Id.btnHome);
			var txtThanks = FindViewById<TextView> (Resource.Id.txtThanks);
			string firstname = Intent.GetStringExtra ("firstname") ?? "";

			txtThanks.Text = "Bedankt voor uw donatie\r\n" + firstname;

			btnHome.Click += delegate {
				var MainActivity = new Intent (this, typeof(MainActivity));
				StartActivity(MainActivity);
			};
		}
	}
}


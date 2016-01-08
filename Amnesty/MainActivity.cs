using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Amnesty
{
	[Activity (Label = "Amnesty", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.btnConfirm);
			
			button.Click += delegate {
				var firstname = FindViewById<EditText>(Resource.Id.txtFirstname).Text;
				var lastname = FindViewById<EditText>(Resource.Id.txtLastname).Text;
				var email = FindViewById<EditText>(Resource.Id.txtEmail).Text;
				var birthdate = FindViewById<EditText>(Resource.Id.txtBirthdate).Text;
				var bankaccount = FindViewById<EditText>(Resource.Id.txtBankaccount).Text;
				var amount = FindViewById<EditText>(Resource.Id.txtAmount).Text;

				var ConfirmationActivity = new Intent(this, typeof(ConfirmationActivity));
				ConfirmationActivity.PutExtra("firstname", firstname);
				ConfirmationActivity.PutExtra("lastname", lastname);
				ConfirmationActivity.PutExtra("email", email);
				ConfirmationActivity.PutExtra("birthdate", birthdate);
				ConfirmationActivity.PutExtra("bankaccount", bankaccount);
				ConfirmationActivity.PutExtra("amount", amount);
				StartActivity (ConfirmationActivity);
			};
		}
	}


}




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
	[Activity (Label = "Vul je gegevens in")]			
	public class FormActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here

			// Set Form View
			SetContentView (Resource.Layout.Form);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.btnConfirm);

			// Get old user info when user wants to change something
			string oldfirstname = Intent.GetStringExtra ("firstname") ?? "";
			string oldlastname = Intent.GetStringExtra ("lastname") ?? "";
			string oldemail = Intent.GetStringExtra ("email") ?? "";
			string oldbankaccount = Intent.GetStringExtra ("bankaccount") ?? "";
			string oldamount = Intent.GetStringExtra ("amount") ?? "";

			var txtFirstname = (EditText) FindViewById(Resource.Id.txtFirstname);
			var txtLastname = (EditText) FindViewById(Resource.Id.txtLastname);
			var txtEmail = (EditText) FindViewById(Resource.Id.txtEmail);
			var txtBankaccount = (EditText) FindViewById(Resource.Id.txtBankaccount);
			var txtAmount = (EditText) FindViewById(Resource.Id.txtAmount);
			txtFirstname.Text = oldfirstname;
			txtLastname.Text = oldlastname;
			txtEmail.Text = oldemail;
			txtBankaccount.Text = oldbankaccount;
			txtAmount.Text = oldamount;

			// go to confirmation screen to display user info.
			button.Click += delegate {
				var firstname = FindViewById<EditText> (Resource.Id.txtFirstname).Text;
				var lastname = FindViewById<EditText> (Resource.Id.txtLastname).Text;
				var email = FindViewById<EditText> (Resource.Id.txtEmail).Text;
				var bankaccount = FindViewById<EditText> (Resource.Id.txtBankaccount).Text;
				var amount = FindViewById<EditText> (Resource.Id.txtAmount).Text;

				var ConfirmationActivity = new Intent (this, typeof(ConfirmationActivity));
				ConfirmationActivity.PutExtra ("firstname", firstname);
				ConfirmationActivity.PutExtra ("lastname", lastname);
				ConfirmationActivity.PutExtra ("email", email);
				ConfirmationActivity.PutExtra ("bankaccount", bankaccount);
				ConfirmationActivity.PutExtra ("amount", amount);
				StartActivity (ConfirmationActivity);
			};
		}
	}
}


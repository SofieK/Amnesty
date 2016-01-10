
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
			string firstname = Intent.GetStringExtra ("firstname") ?? "";
			string lastname = Intent.GetStringExtra ("lastname") ?? "";
			string email = Intent.GetStringExtra ("email") ?? "";
			string streetnr = Intent.GetStringExtra ("streetnr") ?? "";
			string postalcode = Intent.GetStringExtra ("postalcode") ?? "";
			string town = Intent.GetStringExtra ("town") ?? "";
			string bankaccount = Intent.GetStringExtra ("bankaccount") ?? "";
			string amount = Intent.GetStringExtra ("amount") ?? "";

			var txtFirstname = (EditText) FindViewById(Resource.Id.txtFirstname);
			var txtLastname = (EditText) FindViewById(Resource.Id.txtLastname);
			var txtEmail = (EditText) FindViewById(Resource.Id.txtEmail);
			var txtStreetNr = (EditText) FindViewById(Resource.Id.txtStreetNr);
			var txtPostalCode = (EditText) FindViewById(Resource.Id.txtPostalCode);
			var txtTown = (EditText) FindViewById(Resource.Id.txtTown);
			var txtBankaccount = (EditText) FindViewById(Resource.Id.txtBankaccount);
			var txtAmount = (EditText) FindViewById(Resource.Id.txtAmount);
			txtFirstname.Text = firstname;
			txtLastname.Text = lastname;
			txtEmail.Text = email;
			txtStreetNr.Text = streetnr;
			txtPostalCode.Text = postalcode;
			txtTown.Text = town;
			txtBankaccount.Text = bankaccount;
			txtAmount.Text = amount;

			//validation
			txtFirstname.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtFirstname.Text.ToString())){
					txtFirstname.Error = "Verplicht";
				}
			};

			txtLastname.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtLastname.Text.ToString())){
					txtLastname.Error = "Verplicht";
				}
			};

			txtEmail.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtEmail.Text.ToString())){
					txtEmail.Error = "Verplicht";
				}
			};

			txtStreetNr.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtStreetNr.Text.ToString())){
					txtStreetNr.Error = "Verplicht";
				}
			};

			txtPostalCode.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtPostalCode.Text.ToString())){
					txtPostalCode.Error = "Verplicht";
				}
			};

			txtTown.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtTown.Text.ToString())){
					txtTown.Error = "Verplicht";
				}
			};

			txtBankaccount.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtBankaccount.Text.ToString())){
					txtBankaccount.Error = "Verplicht";
				}
			};

			txtAmount.FocusChange += delegate {
				if (String.IsNullOrWhiteSpace(txtAmount.Text.ToString())){
					txtAmount.Error = "Verplicht";
				}
			};

			// go to confirmation screen to display user info.
			button.Click += delegate {
				firstname = FindViewById<EditText> (Resource.Id.txtFirstname).Text;
				lastname = FindViewById<EditText> (Resource.Id.txtLastname).Text;
				email = FindViewById<EditText> (Resource.Id.txtEmail).Text;
				streetnr = FindViewById<EditText> (Resource.Id.txtStreetNr).Text;
				postalcode = FindViewById<EditText> (Resource.Id.txtPostalCode).Text;
				town = FindViewById<EditText> (Resource.Id.txtTown).Text;
				bankaccount = FindViewById<EditText> (Resource.Id.txtBankaccount).Text;
				amount = FindViewById<EditText> (Resource.Id.txtAmount).Text;

				var ConfirmationActivity = new Intent (this, typeof(ConfirmationActivity));
				ConfirmationActivity.PutExtra ("firstname", firstname);
				ConfirmationActivity.PutExtra ("lastname", lastname);
				ConfirmationActivity.PutExtra ("email", email);
				ConfirmationActivity.PutExtra ("streetnr", streetnr);
				ConfirmationActivity.PutExtra ("postalcode", postalcode);
				ConfirmationActivity.PutExtra ("town", town);
				ConfirmationActivity.PutExtra ("bankaccount", bankaccount);
				ConfirmationActivity.PutExtra ("amount", amount);
				StartActivity (ConfirmationActivity);
			};
		}
	}
}


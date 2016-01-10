
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
	[Activity (Label = "Bevestiging")]			
	public class ConfirmationActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Confirmation);

			// Create your application here
			string firstname = Intent.GetStringExtra ("firstname") ?? "Data not available";
			string lastname = Intent.GetStringExtra ("lastname") ?? "Data not available";
			string email = Intent.GetStringExtra ("email") ?? "Data not available";
			string streetnr = Intent.GetStringExtra ("streetnr") ?? "Data not available";
			string postalcode = Intent.GetStringExtra ("postalcode") ?? "Data not available";
			string town = Intent.GetStringExtra ("town") ?? "Data not available";
			string bankaccount = Intent.GetStringExtra ("bankaccount") ?? "Data not available";
			string amount = Intent.GetStringExtra ("amount") ?? "Data not available";

			var txtName = (TextView) FindViewById(Resource.Id.txtName);
			var txtEmail = (TextView) FindViewById(Resource.Id.txtEmail);
			var txtStreetNr = (TextView) FindViewById(Resource.Id.txtStreetNr);
			var txtPostalCode = (TextView) FindViewById(Resource.Id.txtPostalCode);
			var txtTown = (TextView) FindViewById(Resource.Id.txtTown);
			var txtBankaccount = (TextView) FindViewById(Resource.Id.txtBankaccount);
			var txtAmount = (TextView) FindViewById(Resource.Id.txtAmount);
			txtName.Text = firstname + " " +lastname;
			txtEmail.Text = email;
			txtStreetNr.Text = streetnr;
			txtTown.Text = postalcode + " " + town;
			txtBankaccount.Text = bankaccount;
			txtAmount.Text = "€" + amount;

			Button btnChange = FindViewById<Button> (Resource.Id.btnChange);

			btnChange.Click += delegate {
				var FormActivity = new Intent(this, typeof(FormActivity));
				FormActivity.PutExtra ("firstname", firstname);
				FormActivity.PutExtra ("lastname", lastname);
				FormActivity.PutExtra ("email", email);
				FormActivity.PutExtra ("streetnr", streetnr);
				FormActivity.PutExtra ("postalcode", postalcode);
				FormActivity.PutExtra ("town", town);
				FormActivity.PutExtra ("bankaccount", bankaccount);
				FormActivity.PutExtra ("amount", amount);
				StartActivity (FormActivity);
			};

			// user confirms and donates
			Button btnDonate = FindViewById<Button> (Resource.Id.btnDonate);

			btnDonate.Enabled = false;

			CheckBox checkbox = FindViewById<CheckBox>(Resource.Id.chkConfirm);
			checkbox.Click += (o, e) => {
				if (checkbox.Checked)
					btnDonate.Enabled = true;
				else
					btnDonate.Enabled = false;
			};

			btnDonate.Click += delegate {
				var ThankyouActivity = new Intent(this, typeof(ThankyouActivity));
				ThankyouActivity.PutExtra ("firstname", firstname);
				StartActivity(ThankyouActivity);
			};
		}
	}
}


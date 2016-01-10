
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
			string birthdate = Intent.GetStringExtra ("birthdate") ?? "Data not available";
			string bankaccount = Intent.GetStringExtra ("bankaccount") ?? "Data not available";
			string amount = Intent.GetStringExtra ("amount") ?? "Data not available";

			var txtFirstname = (TextView) FindViewById(Resource.Id.txtFirstname);
			var txtLastname = (TextView) FindViewById(Resource.Id.txtLastname);
			var txtEmail = (TextView) FindViewById(Resource.Id.txtEmail);
			var txtBirthdate = (TextView) FindViewById(Resource.Id.txtBirthdate);
			var txtBankaccount = (TextView) FindViewById(Resource.Id.txtBankaccount);
			var txtAmount = (TextView) FindViewById(Resource.Id.txtAmount);
			txtFirstname.Text = firstname;
			txtLastname.Text = lastname;
			txtEmail.Text = email;
			txtBirthdate.Text = birthdate;
			txtBankaccount.Text = bankaccount;
			txtAmount.Text = amount;

			Button btnChange = FindViewById<Button> (Resource.Id.btnChange);

			btnChange.Click += delegate {
				var FormActivity = new Intent(this, typeof(FormActivity));
				FormActivity.PutExtra ("firstname", firstname);
				FormActivity.PutExtra ("lastname", lastname);
				FormActivity.PutExtra ("email", email);
				FormActivity.PutExtra ("birthdate", birthdate);
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


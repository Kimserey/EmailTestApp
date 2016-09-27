using System.IO;

using EmailTestApp;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Java.IO;

[assembly: Dependency(typeof(EmailTestApp.Droid.EmailService_Droid))]
namespace EmailTestApp.Droid
{
	using System;

	public class EmailService_Droid : IEmailService
	{
		public void ShowDraft()
		{
			var email = new Intent(Intent.ActionSend);
			var date = DateTime.UtcNow;
			var backupName = "baskee_" + DateTime.UtcNow.ToString("yyyy_MM_dd__hh_mm_ss") + ".baskee";

			email.PutExtra(Intent.ExtraSubject, "Backup - " + date.ToLongDateString());
			email.PutExtra(Intent.ExtraText, backupName);

			var source = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "test.txt");
			var destination = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, backupName);
			System.IO.File.Copy(source, destination, true);
			var file = new Java.IO.File(destination);

			email.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(file));
			email.SetType("message/rfc822");
			email.SetFlags(ActivityFlags.NewTask);
			Android.App.Application.Context.StartActivity(email);
		}
	}
}

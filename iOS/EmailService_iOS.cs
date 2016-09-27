using System;
using EmailTestApp.iOS;
using MessageUI;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(EmailTestApp.iOS.EmailService_iOS))]
namespace EmailTestApp.iOS
{
	public class EmailService_iOS: IEmailService
	{
		public void ShowDraft()
		{
			var mailer = new MFMailComposeViewController();

			mailer.SetSubject("Hello");
			mailer.SetMessageBody("Hello world", false);
			mailer.Finished += (s, e) => ((MFMailComposeViewController)s).DismissViewController(true, () => { });

			//if (attachments != null)
			//{
			//	foreach (var attachment in attachments)
			//	{
			//		mailer.AddAttachmentData(NSData.FromFile(attachment), GetMimeType(attachment), Path.GetFileName(attachment));
			//	}
			//}

			UIViewController vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
			while (vc.PresentedViewController != null)
			{
				vc = vc.PresentedViewController;
			}
			vc.PresentViewController(mailer, true, null);
		}
	}
}
